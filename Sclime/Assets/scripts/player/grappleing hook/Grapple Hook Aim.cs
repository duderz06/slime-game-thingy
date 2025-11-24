using UnityEngine;

public class GrappleHookAim : MonoBehaviour
{

    public Transform AimCamSpot;
    public Transform Cam;
    public float CamSpeed=3f;

    public float TimeSlow = 0.5f;


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

            Time.timeScale = TimeSlow;

            Aiming=true;

        }

        else {

            Time.timeScale = 1f;

            Aiming = false;
        }


        Reticle.SetActive(Aiming);
    }
}
