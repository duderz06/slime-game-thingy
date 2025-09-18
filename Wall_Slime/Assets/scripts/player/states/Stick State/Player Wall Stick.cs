using UnityEngine;

public class PlayerWallStick : MonoBehaviour
{


    public float speed = 3f;

    private RaycastHit hit;
    public LayerMask groundLayer;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.linearVelocity = new Vector3(0, 0, 0);

        float arcAngle = 270;
        float arcRadius = speed;
        int arcResolution = 6;

        if (Input.GetKey(KeyCode.W))
        {

            if (ArcCast(transform.position, transform.rotation,
            arcAngle, arcRadius, arcResolution, groundLayer, out RaycastHit hit))
            {


                transform.position = hit.point;
                transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            }

        }



    }

    


    static public bool ArcCast(Vector3 center, Quaternion rotation,
        float angle, float radius, int resolution, LayerMask layer,
        out RaycastHit hit)
    { 
    
        rotation *= Quaternion.Euler(-angle/2, 0, 0);

        for (int i = 0; i < resolution; i++) { 
        
            Vector3 A = center + rotation * Vector3.forward * radius;
            rotation *= Quaternion.Euler(angle / resolution, 0, 0);
            Vector3 B = center+rotation * Vector3.forward * radius;
            Vector3 AB = B - A;


            Debug.DrawLine(A, B, Color.red, 0.1f);


            if (Physics.Raycast(A, AB, out hit, AB.magnitude * 1.001f, layer)) {
                Debug.DrawLine(A, hit.point, Color.green, 0.1f);
                Debug.DrawRay(hit.point, hit.normal * 0.5f, Color.cyan, 0.1f);
                return true;
            
            }
        
        
        }
    

        hit = new RaycastHit();
        return false;

    }



}
