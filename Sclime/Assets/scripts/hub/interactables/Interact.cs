using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{


    public GameObject player;
    private GameObject e;
    public bool playerinrange = false;


    public LayerMask Playerlayer;

    public float range = 3f;


    public string methodtodo;

    private bool showe=false;
    private MeshRenderer emr;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        Transform child = transform.Find("E");
        GameObject e = child.gameObject;

        emr = e.GetComponent<MeshRenderer>();

    }
    void FixedUpdate()
    {
        Vector3 directiontoplayer = (player.transform.position - transform.position).normalized;

        RaycastHit hit;
        bool didhit = Physics.Raycast(transform.position, directiontoplayer, out hit, range, Playerlayer);


        if (didhit)
        {

            playerinrange = true;


        }


        else
        {


            playerinrange = false;


        }



        Debug.DrawRay(transform.position, directiontoplayer * range, Color.red);


    }



    void Update() {

        emr.enabled = showe;


        if (!playerinrange) {
            showe = false;


        }

        if (playerinrange)
        {

            showe = true;


            if (Input.GetKeyDown(KeyCode.E))
            {



                SendMessage(methodtodo, SendMessageOptions.DontRequireReceiver);


            }


        }

       

    }





}
