using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float speed = 3f;

    private RaycastHit hit;
    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        float arcAngle = 270;
        float arcRadius = speed * Time.deltaTime;
        int arcResolution = 6;

                if (ArcCast(transform.position, transform.rotation,
            arcAngle, arcRadius, arcResolution, groundLayer, out RaycastHit hiy))
        {

            transform.position = hit.point;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        
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

            if (Physics.Raycast(A, AB, out hit, AB.magnitude * 1.001f, layer)) { 
            
                return true;
            
            }
        
        
        }
    

        hit = new RaycastHit();
        return false;

    }



}
