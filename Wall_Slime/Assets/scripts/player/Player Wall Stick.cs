using UnityEngine;
using System.Collections.Generic;

public class PlayerWallStick : MonoBehaviour
{
    private Rigidbody rb;
    public PlayerMovement pm;

    public float speed = 3f;
    public bool isMoving = false;
    public bool isStick = true;

    [Header("Stick")]
    private RaycastHit hit;
    public LayerMask groundLayer;
    public Transform player;
    public Quaternion rot = Quaternion.Euler(0, 0, 0);

    [Header("Strafe")]
    public float strafeSpeed = 2f;
    
    [Header("Jump")]
    public float jumpForce = 5f;
    public float jumpLenaincy = 0.2f;
    public bool jumping = false;
    public bool grounded = true;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumping = true;
            grounded = false;
            Invoke(nameof(Jump), 0.05f);
        }*/

        if (!grounded || !isStick)
        {
            rb.useGravity = true;
            Strafe();
        }
}

    private void Strafe()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0f, vertical); 
        direction = transform.forward * vertical + transform.right * horizontal;

        rb.AddForce(direction * strafeSpeed, ForceMode.Acceleration);
    }

    private void Jump()
    {
        rb.AddForce(player.up * jumpForce, ForceMode.Impulse);
        player.rotation = Quaternion.identity;

        Invoke(nameof(ResetLeniancy), jumpLenaincy);
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            rb.useGravity = false;
            rb.linearVelocity = new Vector3(0, 0, 0);
        }

        float arcAngle = 270;
        float arcRadius = speed;
        int arcResolution = 6;

        if (!jumping && isStick)
        {
            if (ArcCast(transform.position, transform.rotation * rot,
            arcAngle, arcRadius, arcResolution, groundLayer, out RaycastHit hit))
            {
                grounded = true;
                if (isMoving)
                {
                    player.position = hit.point;
                    player.rotation = Quaternion.FromToRotation(player.up, hit.normal) * player.rotation;
                }
            }
            else
            {
                grounded = false;
            }
        }
    }

    private void ResetLeniancy()
    {
        jumping = false;
    }

    static public bool ArcCast(Vector3 center, Quaternion rotation,
        float angle, float radius, int resolution, LayerMask layer,
        out RaycastHit hit)
    {
        rotation *= Quaternion.Euler(-angle / 2, 0, 0);

        for (int i = 0; i < resolution; i++)
        {
            Vector3 A = center + rotation * Vector3.forward * radius;
            rotation *= Quaternion.Euler(angle / resolution, 0, 0);
            Vector3 B = center + rotation * Vector3.forward * radius;
            Vector3 AB = B - A;

            Debug.DrawLine(A, B, Color.red, 0.1f);

            if (Physics.Raycast(A, AB, out hit, AB.magnitude * 1.001f, layer))
            {
                Debug.DrawLine(A, hit.point, Color.green, 0.1f);
                Debug.DrawRay(hit.point, hit.normal * 0.5f, Color.cyan, 0.1f);
                return true;
            }
        }

        hit = new RaycastHit();
        return false;
    }
}