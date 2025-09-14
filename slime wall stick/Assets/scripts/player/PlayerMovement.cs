using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public GameObject Camera;
    public Rigidbody rb;

    public float Speed = 3f;
    public PlayerStick ps;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3(0,0,0);
        Vector3 camForward = Camera.transform.forward;
        Vector3 camRight = Camera.transform.right;

        if (Input.GetAxis("Vertical") >0) {

            movement += camForward * Speed;
        
        }

        if (Input.GetAxis("Vertical") <0)
        {

            movement -= camForward * Speed;

        }

        if (Input.GetAxis("Horizontal") > 0)
        {

            movement += camRight * Speed;

        }

        if (Input.GetAxis("Horizontal") < 0)
        {

            movement -= camRight * Speed;

        }





        if (ps.OnXAxis) {

            movement.x = rb.velocity.x;


        }

        if (ps.OnYAxis)
        {

            movement.y = rb.velocity.y;


        }

        if (ps.OnZAxis)
        {

            movement.z = rb.velocity.z;


        }

        if (movement != Vector3.zero && !(movement.x != 0 && movement.y != 0 && movement.z != 0))
        {
            transform.forward = movement;
        }




        rb.velocity = movement;
    }



}