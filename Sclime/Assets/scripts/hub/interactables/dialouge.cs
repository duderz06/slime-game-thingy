using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dialouge : MonoBehaviour
{


    public List<string> dialog;
    private GameObject dialogbox;
    private TextMeshProUGUI dialogtext;


    private GameObject player;


    public bool istalking = false;

    private int whichtext = 0;

    private string substring;

    private float texttimer;
    public float maxtexttimer;

    private int i;


    private PlayerWallStick PWS;
    private StateHandler SH;


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

            PWS.enabled = false;
            SH.enabled = false;

          
            dialogbox.SetActive(true);
            dialogtext.text = "";

            playerpos=player.transform.position;

         



        
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
            PWS.enabled = true;
            SH.enabled = true;

            dialogbox.SetActive(false);
            dialogtext.text = "";





        }


    }
    

    void Awake()
    {

        player = GameObject.FindWithTag("Player");

        donetalking = false;
        amountofsfx = sfx.Count;


        PWS = FindAnyObjectByType<PlayerWallStick>();
        SH = FindAnyObjectByType<StateHandler>();


        dialogbox = GameObject.Find("dialog box");
        dialogtext = GameObject.Find("dialog text").GetComponent<TextMeshProUGUI>();

    }

    void Start()
    {
        dialogbox.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

        if (istalking)
        {


            player.transform.position = playerpos;


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
