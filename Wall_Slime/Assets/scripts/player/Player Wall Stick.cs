using UnityEngine;

public class PlayerWallStick : MonoBehaviour
{


    public float speed = 3f;
    public bool isMoving = false;

    private RaycastHit hit;
    public LayerMask groundLayer;
    public Transform player;
    private Rigidbody rb;
    private Vector3 direction;
    public Quaternion rot = Quaternion.Euler(0, 0, 0);

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(0, 0, 0);

        float arcAngle = 270;
        float arcRadius = speed;
        int arcResolution = 6;

        if (isMoving)
        {
            if (ArcCast(transform.position, transform.rotation * rot,
            arcAngle, arcRadius, arcResolution, groundLayer, out RaycastHit hit))
            {
                player.position = hit.point;
                player.rotation = Quaternion.FromToRotation(player.up, hit.normal) * player.rotation;
            }
        }
    }

    static public bool ArcCast(Vector3 center, Quaternion rotation,
        float angle, float radius, int resolution, LayerMask layer,
        out RaycastHit hit)
    { 
        rotation *= Quaternion.Euler(-angle/2, 0, 0);

        for (int i = 0; i < resolution; i++)
        { 
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
