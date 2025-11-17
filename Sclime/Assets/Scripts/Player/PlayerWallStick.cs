using UnityEngine;
using System.Collections.Generic;

public class PlayerWallStick : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;

    public float speed = 3f;
    public bool isMoving = false;
    private bool isStick = true;

    [Header("Stick")]
    private RaycastHit hit;
    public LayerMask groundLayer;
    public Transform player;
    public Quaternion rot = Quaternion.Euler(0, 0, 0);
    private bool unsticking = false;
    private bool queUnstick = false;

    [Header("Raycast")]
    public int arcResolution = 6;
    public float arcAngle = 270f;
    private float arcRadius;

    [Header("Strafe")]
    public float strafeSpeed = 5f;
    private bool strafing = false;
    
    [Header("Jump")]
    public float jumpForce = 10f;
    private float jumpLeniency = 0.5f;
    private bool grounded = false;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        arcRadius = speed;
    }

    private void Update()
    {
        if (!grounded || !isStick)
        {
            rb.useGravity = true;
            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");

            direction = transform.forward * vertical + transform.right * horizontal;
            strafing = true;
        }
        else
        {
            strafing = false;
        }
    }

    public void SwapState(bool stick)
    {
        isStick = stick;

        if (!isStick && grounded)
        {
            queUnstick = true;
        }
    }

    private void Unstick()
    {
        unsticking = true;
        grounded = false;
        Invoke(nameof(Eject), 0.01f);
    }

    private void Eject() //launches player from wall if unsticking or switching
    {
        rb.AddForce(player.up + direction * jumpForce, ForceMode.Impulse);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        player.rotation = Quaternion.identity;
        Invoke(nameof(ResetLeniancy), jumpLeniency);
    }

    void FixedUpdate()
    {
        if (strafing)
        {
            rb.AddForce(direction.normalized * strafeSpeed, ForceMode.Force);
        }

        if (!queUnstick && !unsticking && isStick)
        {
            if (ArcCast(transform.position, transform.rotation * rot,
            arcAngle, arcRadius, arcResolution, groundLayer, out RaycastHit hit))
            {
                grounded = true;
                if (isMoving && !unsticking)
                {
                    //rb.MovePosition(hit.point);
                    player.position = hit.point;
                    player.rotation = Quaternion.FromToRotation(player.up, hit.normal) * player.rotation;
                }

                rb.useGravity = false;
                rb.linearVelocity = Vector3.zero;
            }
            // else if (grounded)
            // {
            //     queUnstick = true;
            // }
        }

        if (queUnstick)
        {
            Unstick();
            queUnstick = false;
        }
    }

    private void ResetLeniancy()
    {
        unsticking = false;
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

            // Debug.DrawLine(A, B, Color.red, 0.1f);

            if (Physics.Raycast(A, AB, out hit, AB.magnitude * 1.001f, layer))
            {
            //     Debug.DrawLine(A, hit.point, Color.green, 0.1f);
            //     Debug.DrawRay(hit.point, hit.normal * 0.5f, Color.cyan, 0.1f);
                return true;
            }
        }

        hit = new RaycastHit();
        return false;
    }
}