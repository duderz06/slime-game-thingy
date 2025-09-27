using UnityEngine;
using UnityEngine.UI;
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

    public ParticleSystem PlayerGrowParticles;
    public ParticleSystem GlassBreakParticle;

    public PlayerMovement PM;

    public GameObject FadeObj;
    public Image Fade;
    public float FadeSpeed = 1f;
    public Color FadedColor;
    public Color FullColor;


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
        PM.enabled = false;

        PlayerGrowParticles.Stop();


        bool glass1=false;
        bool glass2=false;
        bool glass3=false;

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


            if (hits < quarterhits&&!glass1)
            {

                glass1=true;

                TubeGlass1.SetActive(true);
                TubeGlass2.SetActive(false);
                TubeGlass3.SetActive(false);


            }

            if (hits >= quarterhits && hits < quarterhits * 2 && !glass2)
            {

                TubeGlass1.SetActive(false);
                TubeGlass2.SetActive(true);
                TubeGlass3.SetActive(false);

                glass2 = true;
                GlassBreakParticle.Play();

            }

            if (hits >= quarterhits * 2 && hits < quarterhits * 3 && !glass3)
            {

                TubeGlass1.SetActive(false);
                TubeGlass2.SetActive(false);
                TubeGlass3.SetActive(true);

                glass3 = true;
                GlassBreakParticle.Play();

            }



            yield return null;
        }


        TubeGlass1.SetActive(false);
        TubeGlass2.SetActive(false);
        TubeGlass3.SetActive(false);
        Hint.SetActive(false);
        GlassBreakParticle.Play();


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
        yield return new WaitForSeconds(0.5f);

        PlayerGrowParticles.Play();

        yield return new WaitForSeconds(0.5f);


        bool StartedPlayerGrow =false;
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

        PlayerGrowParticles.Play();

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



        }

        yield return new WaitForSeconds(0.5f);

        StartCoroutine("FadeInOut");

        yield return new WaitForSeconds(0.5f);


        Destroy(StartCamera);
        PlayerRaycaster.SetActive(true);
        PM.enabled = true;
        PlayerGrowParticles.Stop();




    }




    public IEnumerator FadeInOut() {

        FadeObj.SetActive(true);

        Color ImgCol = Fade.color;

        while (ImgCol.a < 0.95f) {

      

            ImgCol = Color.Lerp(ImgCol, FullColor, FadeSpeed*Time.deltaTime);

            Fade.color = ImgCol;

            yield return null;
        }

        ImgCol.a = 255;

        yield return new WaitForSeconds(0.1f);


        while (ImgCol.a > 0.05f)
        {
     


            ImgCol = Color.Lerp(ImgCol, FadedColor, FadeSpeed * Time.deltaTime);

            Fade.color = ImgCol;



            yield return null;
        }

        FadeObj.SetActive(false);

    }

}
