using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 40;
    public float friction = 5;
    public Vector2 velocity = Vector2.zero;

    private float speed = 0;

    public float rotationSpeed = 90;

    public GameObject Camera;

    void Update()
    {

        ApplyAcceleration();
        ApplyFriction();

        UpdateSpeed();


        ApplyVelocity();

        Rotate();



    }

    void ApplyAcceleration()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            //dir.y += 1;

        }

        if (Input.GetKey(KeyCode.S)) 
        { 
            dir.y -= 1; 

        }

        if (Input.GetKey(KeyCode.D))
        {
            dir.x += 1;

        }

        if (Input.GetKey(KeyCode.A))
        {
            dir.x -= 1;

        }


        if (dir != Vector2.zero)
        {

            dir.Normalize();

            velocity += acceleration * Time.deltaTime * dir;

        }


    }

    void ApplyFriction()
    {

        velocity -= friction * Time.deltaTime * velocity;

    }

    void UpdateSpeed()
    {

        speed = velocity.magnitude;

    }

    void ApplyVelocity()
    {

        transform.Translate(new Vector3(velocity.x, 0, velocity.y) * Time.deltaTime);

    }

    void Rotate()
    {
       
        float dir = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            dir -= 1;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir += 1;

        }

        transform.Rotate(0, rotationSpeed * Time.deltaTime * dir, 0);

      



        //tried to have it be based off the camera but that broke everything
        //transform.rotation = Quaternion.Euler(0f, Camera.transform.eulerAngles.y, 0f);



    }


}

