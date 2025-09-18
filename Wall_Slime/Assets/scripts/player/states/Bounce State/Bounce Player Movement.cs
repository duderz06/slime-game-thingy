using UnityEngine;

public class BouncePlayerMovement : MonoBehaviour
{

    private GameObject Camera;


    private Rigidbody rb;

    public float Speed = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Camera = GameObject.FindWithTag("MainCamera");

        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //this line makes it not carry momentum but i couldnt figure out a good way to have keep momentum while still giving the player control
        Vector3 movement = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W)) {


            movement += Camera.transform.forward * Speed;

        }
        if (Input.GetKey(KeyCode.S))
        {


            movement -= Camera.transform.forward * Speed;


        }


        if (Input.GetKey(KeyCode.D))
        {


            movement += Camera.transform.right * Speed;


        }

        if (Input.GetKey(KeyCode.A))
        {


            movement -= Camera.transform.right * Speed;


        }

      


        movement.y = rb.linearVelocity.y;

        rb.linearVelocity = movement;



    }


}
