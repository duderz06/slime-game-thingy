using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchWallsOld : MonoBehaviour
{

    public float RaycastLength = 1f;
    public LayerMask Stickable;



    // Start is called before the first frame update
    void Start()
    {
       
        




    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;



        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RaycastLength, Color.red);


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, RaycastLength, Stickable))
        {

            Quaternion TargetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            transform.rotation = TargetRotation;


        }




    }




}
