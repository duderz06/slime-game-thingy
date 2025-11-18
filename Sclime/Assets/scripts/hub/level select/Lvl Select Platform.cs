using UnityEngine;

public class LvlSelectPlatform : MonoBehaviour
{



    public bool PlayerOn=false;

    public Transform StandOnCamSpot;
    public Transform PlayerCamSpot;

    private CameraFollow CF;
    private PlayerLook PL;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CF = FindObjectOfType<CameraFollow>();
        PL = FindObjectOfType<PlayerLook>();


    }

    // Update is called once per frame
    void Update()
    {

       



    }


    private void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player")) { 
        
            PlayerOn=true;

            CF.target = StandOnCamSpot;

            PL.ToggleCursor();

        }


    }



    private void OnTriggerExit(Collider col) {


        if (col.CompareTag("Player"))
        {

            PlayerOn = false;
            CF.target = PlayerCamSpot;
            PL.ToggleCursor();

        }

    }



}
