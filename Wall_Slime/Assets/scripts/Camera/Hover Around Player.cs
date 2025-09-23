using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAroundPlayer : MonoBehaviour
{
    private GameObject player;
    public Transform RotationHolder;
    public float Distance = 10.0f;
    public float MaxDistance = 15.0f;
    public float MinDistance = 3.0f;
    public float MouseSensitivity = 3.0f;
    public float PitchMin = -20f;         
    public float PitchMax = 80f;          

    private float yaw = 0f;               
    private float pitch = 20f;

    public bool off = false;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");

      


    }
    void LateUpdate()
    {
        if (!off)
        {

            if (player != null)
            {

                yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
                pitch += Input.GetAxis("Mouse Y") * MouseSensitivity;

                pitch = Mathf.Clamp(pitch, PitchMin, PitchMax);

                Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
                Vector3 direction = rotation * new Vector3(0, 0, -Distance);
                Vector3 campos = player.transform.position + direction;

                transform.transform.position = campos;            
                transform.LookAt(player.transform.position);




                float scroll = Input.GetAxis("Mouse ScrollWheel");

                if (scroll < 0)
                {

                    Distance += 0.25f;
                    if (Distance > MaxDistance)
                    {

                        Distance = MaxDistance;

                    }


                }



                if (scroll > 0)
                {

                    Distance -= 0.25f;
                    if (Distance < MinDistance)
                    {

                        Distance = MinDistance;

                    }


                }

            }

        }
    }



}
