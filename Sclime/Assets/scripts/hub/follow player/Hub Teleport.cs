using System.Collections;
using UnityEngine;

public class HubTeleport : MonoBehaviour
{

    public GameObject Player;

    public Transform TeleportLocation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player")) { 
            StartCoroutine("Teleport");
        
        
        }


        
    }


    public IEnumerator Teleport() { 
    
    
        yield return null;
    
        Player.transform.position = TeleportLocation.position;
    
    }

}
