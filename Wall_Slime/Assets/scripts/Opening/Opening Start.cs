using UnityEngine;
using System.Collections;

public class OpeningStart : MonoBehaviour
{

    public GameObject Player;
    public GameObject StartCamera;
    public GameObject PlayerRaycaster;

    public GameObject TubeGlass1;
    public GameObject TubeGlass2;
    public GameObject TubeGlass3;

    public GameObject Hint;

    public int MaxHits = 25;


    public GameObject TubeGoo;
    public float TubeGooFallSpeed = 1f;
    public float TubeGooSpreadSpeed = 1f;

    public Transform GooFlowSpot;
    public float GooFlowSpeed = 1f;

    public float TubeGooShrinkSpeed = 5f;
    public float PlayerGrowSpeed = 5f;

    public GameObject PlayerGrowParticles;

    public PlayerMovement PM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        StartCoroutine("BreakTube");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public IEnumerator BreakTube()
    {

        int hits = 0;

        float quarterhits = MaxHits / 4f;

        float timer = 0f;

        Player.SetActive(false);
        PlayerRaycaster.SetActive(false);
        PlayerGrowParticles.SetActive(false);
        PM.enabled = false;

        while (hits < MaxHits)
        {
            timer += Time.deltaTime;

            if (timer >= 10f)
            {


                Hint.SetActive(true);

            }


            if (Input.anyKeyDown)
            {


                hits++;

                //maybe add some camera shake

            }


            if (hits < quarterhits)
            {

                TubeGlass1.SetActive(true);
                TubeGlass2.SetActive(false);
                TubeGlass3.SetActive(false);


            }

            if (hits >= quarterhits && hits < quarterhits * 2)
            {

                TubeGlass1.SetActive(false);
                TubeGlass2.SetActive(true);
                TubeGlass3.SetActive(false);


            }

            if (hits >= quarterhits * 2 && hits < quarterhits * 3)
            {

                TubeGlass1.SetActive(false);
                TubeGlass2.SetActive(false);
                TubeGlass3.SetActive(true);


            }



            yield return null;
        }


        TubeGlass1.SetActive(false);
        TubeGlass2.SetActive(false);
        TubeGlass3.SetActive(false);
        Hint.SetActive(false);


        StartCoroutine("SlimeFlow");

    }


    public IEnumerator SlimeFlow()
    {

        while (TubeGoo.transform.localScale.y > 0.85f)
        {

            Vector3 size = TubeGoo.transform.localScale;

            size.y -= TubeGooFallSpeed * Time.deltaTime;
            size.x += TubeGooSpreadSpeed * Time.deltaTime;
            size.z += TubeGooSpreadSpeed * Time.deltaTime;


            TubeGoo.transform.localScale = size;
            yield return null;
        }

        yield return new WaitForSeconds(1f);


        while (Vector3.Distance(TubeGoo.transform.position, GooFlowSpot.position) > 0.01f)
        {

            TubeGoo.transform.position = Vector3.MoveTowards(TubeGoo.transform.position, GooFlowSpot.position, GooFlowSpeed * Time.deltaTime);

            yield return null;
        }

        TubeGoo.transform.position = GooFlowSpot.position;

        yield return new WaitForSeconds(1f);


        bool StartedPlayerGrow=false;
        while (TubeGoo.transform.localScale != new Vector3(0, 0, 0))
        {

            Vector3 size = TubeGoo.transform.localScale;

            if (size.y > 0)
            {

                size.y -= TubeGooShrinkSpeed * Time.deltaTime;

            }
            else {

                size.y = 0;

                if (!StartedPlayerGrow) { 
                
                    StartedPlayerGrow = true;
                    StartCoroutine("GrowPlayer");
                
                }

            }
            if (size.x > 0)
            {

                size.x -= TubeGooShrinkSpeed * Time.deltaTime;

            }
            else
            {

                size.x = 0;


            }
            if (size.z > 0)
            {

                size.z -= TubeGooShrinkSpeed * Time.deltaTime;

            }
            else
            {

                size.z = 0;


            }

            TubeGoo.transform.localScale = size;

            yield return null;

        }


        Destroy(TubeGoo);
        
    }


    public IEnumerator GrowPlayer() {

        PlayerGrowParticles.SetActive(true);

        Player.transform.localScale = new Vector3(0, 0, 0);
        Player.SetActive(true);

        while (Player.transform.localScale != new Vector3(1, 1, 1))
        {

            Vector3 size = Player.transform.localScale;

            if (size.y < 1)
            {

                size.y += PlayerGrowSpeed * Time.deltaTime;

            }
            else
            {

                size.y = 1;


            }
            if (size.x < 1)
            {

                size.x += PlayerGrowSpeed * Time.deltaTime;

            }
            else
            {

                size.x = 1;


            }
            if (size.z < 1)
            {

                size.z += PlayerGrowSpeed * Time.deltaTime;

            }
            else
            {

                size.z = 1;


            }

            Player.transform.localScale = size;

            yield return null;

        }

        yield return new WaitForSeconds(1f);


        Destroy(StartCamera);
        PlayerRaycaster.SetActive(true);
        PM.enabled = true;
        PlayerGrowParticles.SetActive(false);




    }

}
