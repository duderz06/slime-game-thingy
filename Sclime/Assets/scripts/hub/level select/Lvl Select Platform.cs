using UnityEngine;

public class LvlSelectPlatform : MonoBehaviour
{



    public bool PlayerOn=false;

    public Transform StandOnCamSpot;
    public Transform PlayerCamSpot;

    private CameraFollow CF;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CF = FindObjectOfType<CameraFollow>();


    }

    // Update is called once per frame
    void Update()
    {

       



    }


    private void OnTriggerStay(Collider col)
    {

        if (col.CompareTag("Player")) { 
        
            PlayerOn=true;

            CF.target = StandOnCamSpot;


        }


    }



    private void OnTriggerExit(Collider col) {


        if (col.CompareTag("Player"))
        {

            PlayerOn = false;
            CF.target = PlayerCamSpot;

        }

    }



}
