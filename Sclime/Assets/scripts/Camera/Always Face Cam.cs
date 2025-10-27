using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFaceCam : MonoBehaviour
{

    public GameObject cam;


    public bool toplookat = false;



    void Start() {

         cam = GameObject.FindWithTag("MainCamera");


    }

    // Update is called once per frame
    void Update()
    {

        if (toplookat)
        {
            Vector3 dir = cam.transform.position - transform.position;
            Quaternion lookrotate = Quaternion.LookRotation(dir);

            transform.rotation = lookrotate * Quaternion.Euler(90, 0, 0);
        }

        else {

            transform.LookAt(cam.transform);

        }


    }



}
