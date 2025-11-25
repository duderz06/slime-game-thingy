using UnityEngine;

public class GrappleHookAim : MonoBehaviour
{

    public Transform AimCamSpot;
    public Transform Cam;
    public float CamSpeed=3f;



    public bool Aiming = false;

    public GameObject Reticle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(1))
        {
            Cam.position = AimCamSpot.position;


            Aiming=true;

        }


        else if (Input.GetMouseButtonUp(1)) { 


            Aiming = false;
        }
        




        Reticle.SetActive(Aiming);
    }
}
