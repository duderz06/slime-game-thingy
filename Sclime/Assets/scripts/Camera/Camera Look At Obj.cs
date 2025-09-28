using UnityEngine;

public class CameraLookAtObj : MonoBehaviour
{

    public Transform Obj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Obj != null)
        {
            Vector3 dir = (Obj.position - transform.position).normalized;


            transform.forward = dir;
        }

    }




}
