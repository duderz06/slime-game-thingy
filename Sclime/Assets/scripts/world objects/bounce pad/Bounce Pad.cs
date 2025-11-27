using UnityEngine;

public class BouncePad : MonoBehaviour
{

    public float Power = 30f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col) {

        if (col.CompareTag("Player")) { 
        
            Rigidbody rb = col.GetComponent<Rigidbody>();
            rb.linearVelocity = Power * transform.up;
        
        }
    
    
    }

}
