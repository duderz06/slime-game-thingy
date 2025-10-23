using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialouge : MonoBehaviour
{


    public List<string> dialog;
    public GameObject dialogbox;
    public TextMeshProUGUI dialogtext;


    private GameObject player;
    private GameObject cam;
    private GameObject canvas;
    public GameObject campoint;


    public bool istalking = false;

    private int whichtext = 0;

    private string substring;

    private float texttimer;
    public float maxtexttimer;

    private int i;



   

    private float camspeed = 5f;


    public List<AudioClip> sfx = new List<AudioClip> { };
    private int amountofsfx = 0;

    private bool donetalking=false;

    private Vector3 playerpos;

    public void starttalk(){

        if (!istalking)
        {
            istalking = true;
            whichtext = 0;
            substring = "";
            i = 0;
            donetalking = false;

          
            dialogbox.SetActive(true);
            dialogtext.text = "";

            playerpos=player.transform.position;

            Vector3 midpoint = (this.transform.position + player.transform.position) / 2f;

           

            float dist = Vector3.Distance(this.transform.position, player.transform.position);


            GameObject mid =Instantiate(campoint, midpoint, Quaternion.identity);

            mid.transform.LookAt(player.gameObject.transform);



            Vector3 offset = mid.transform.right * (dist * 2f);

            GameObject point1 = Instantiate(campoint, mid.transform.position + offset, Quaternion.identity);
            GameObject point2 = Instantiate(campoint, mid.transform.position - offset, Quaternion.identity);

            Destroy(mid);

        }

    }


    public void endtalk()
    {
        if (istalking)
        {
            istalking = false;
            whichtext = 0;
            substring = "";
            i = 0;
            donetalking = false;


            dialogbox.SetActive(false);
            dialogtext.text = "";


            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("dialog cam point"))
            {

                Destroy(obj);


            }




        }


    }
    

    void Start()
    {

        player = GameObject.FindWithTag("Player");
        cam = GameObject.FindWithTag("MainCamera");
        canvas = GameObject.FindWithTag("canvas");
       

        donetalking = false;
        amountofsfx = sfx.Count;


    }


    // Update is called once per frame
    void Update()
    {

        if (istalking)
        {


            player.transform.position = playerpos;

            float closedist = Mathf.Infinity;

            Vector3 midpoint = (this.transform.position + player.transform.position) / 2f;
            Vector3 pointcamgo = new Vector3(0,0,0);


            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("dialog cam point"))
            {

                float distance = Vector3.Distance(obj.transform.position, cam.transform.position);
                if (distance < closedist)
                {

                    closedist = distance;
                    pointcamgo = obj.transform.position;


                }



            }

            cam.transform.position = Vector3.Lerp(cam.transform.position, pointcamgo, camspeed * Time.deltaTime);

            //cam.transform.position= pointcamgo;
            cam.transform.LookAt(midpoint);



            texttimer += Time.deltaTime;

            if (texttimer >= maxtexttimer) {
                substring = dialog[whichtext].Substring(0, i);

                if (amountofsfx > 0&&!donetalking)
                {
                    
                    GameObject cam = GameObject.FindWithTag("MainCamera");

                    AudioClip sfxtoplay = sfx[Random.Range(0, amountofsfx)];

                    GameObject tempsound = new GameObject("talk noise");

                    tempsound.transform.SetParent(this.transform);
                    tempsound.transform.position = this.transform.position;

                    AudioSource soundsource = tempsound.AddComponent<AudioSource>();
                    soundsource.clip = sfxtoplay;
                    soundsource.spatialBlend = 1f;
                    soundsource.minDistance = 5f;
                    //soundsource.maxDistance = 50f; 
                    soundsource.Play();
                    soundsource.dopplerLevel = 0f;

                    Destroy(tempsound, sfxtoplay.length);


                }



            }


            dialogtext.text = substring;

            if (i >= dialog[whichtext].Length)
            {
                donetalking = true;
                if (Input.GetKeyDown(KeyCode.Space)) {
                    
                    i = 0;
                    whichtext++;
                    texttimer = 0f;
                    donetalking = false;

                }

                if (whichtext >= dialog.Count) {

                    endtalk();
                    texttimer = 0f;
                    donetalking = false;

                }

            }
            else if (texttimer >= maxtexttimer)
            {
                i++;
                texttimer = 0f;
            }







        }



    }




}
