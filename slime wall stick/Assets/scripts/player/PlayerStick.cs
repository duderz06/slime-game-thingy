using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStick : MonoBehaviour
{


    public Vector3 NormalHit;

    public LayerMask Stickable;  


    public float RaycastRange = 5f;


    public bool stuck = false;         

    public Rigidbody rb;

    public float StickingPower = 50f;


    public bool OnXAxis=false;
    public bool OnYAxis=false;
    public bool OnZAxis=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, RaycastRange, Stickable))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);



            NormalHit = hit.normal;


            stuck = true;

        }

        else {

            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * RaycastRange, Color.red);

            stuck=false;
        }

        OnXAxis = false;
        OnYAxis = false;
        OnZAxis = false;

        float AbsoluteX = Mathf.Abs(NormalHit.x);
        float AbsoluteY = Mathf.Abs(NormalHit.y);
        float AbsoluteZ = Mathf.Abs(NormalHit.z);

        if (AbsoluteX > AbsoluteY && AbsoluteX > AbsoluteZ)
        {

            OnXAxis = true;

        }



        else if (AbsoluteY > AbsoluteX && AbsoluteY > AbsoluteZ)
        {

            OnYAxis = true;


        }

        else
        {



            OnZAxis = true;
        }


    }




    void FixedUpdate()
    {

        if (stuck)
        {

            rb.useGravity = false;

            rb.AddForce(-NormalHit * StickingPower, ForceMode.Acceleration);

        }


        else
        {


            rb.useGravity = true;

            OnXAxis = false;
            OnYAxis = false;
            OnZAxis = false;

        }       

    }











}
