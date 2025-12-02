using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishByPlayer : MonoBehaviour
{
    private float BaseSize;
    private float BaseSpot;

    private bool SteppedOn = false;
    public float ShrinkPercent = 0.75f;

    public float TransitionSpeed = 5f; 

    private Vector3 ScaleWant;
    private Vector3 PosWant;

    void Start()
    {

        BaseSize = this.transform.localScale.y;
        BaseSpot = this.transform.position.y;

        ScaleWant = transform.localScale;

        PosWant = transform.position;


    }

    void Update()
    {

        if (SteppedOn)
        {
            ScaleWant = new Vector3(transform.localScale.x, BaseSize * ShrinkPercent, transform.localScale.z);
            PosWant = new Vector3(transform.position.x, BaseSpot - (ShrinkPercent / 4), transform.position.z);

        }


        else
        {
            ScaleWant = new Vector3(transform.localScale.x, BaseSize, transform.localScale.z);
            PosWant = new Vector3(transform.position.x, BaseSpot, transform.position.z);


        }

        transform.localScale = Vector3.Lerp(transform.localScale, ScaleWant, Time.deltaTime * TransitionSpeed);
        transform.position = Vector3.Lerp(transform.position, PosWant, Time.deltaTime * TransitionSpeed);



    }

    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.CompareTag("Player"))
        {

            SteppedOn = true;
        }


    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.CompareTag("Player"))
        {

            SteppedOn = false;
        }



    }



}
