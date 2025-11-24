using System.Collections;
using System.Net;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] private Rigidbody m_Rigidbody; // The same rigidbody used by PlayerWallStick
    [SerializeField] private KeyCode m_GrappleButton = KeyCode.Mouse1; // usually RMB

    [SerializeField] private PlayerWallStick m_WallStick; // Should be the player movement currently active
    [SerializeField] private PlayerMovement m_PlayerMovement; // Should be the player movement currently active
    [SerializeField] private Transform m_Camera;
    [SerializeField] private Transform m_ShootLocation;
    [SerializeField] private Transform m_Player;

    [SerializeField] private float m_MaxGrappleDistance;
    [SerializeField] private float m_GrappleTime;
    [SerializeField] private float m_EndGrapple;
    [SerializeField] private LayerMask m_GrappleLayers;
    [SerializeField] private float m_GrappleHeight;

    [SerializeField] private float m_GrappleCooldown;


    private Vector3 m_GrappleLoc;

    public bool Grappling { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(m_GrappleButton))
        {
            if (!Grappling)
                StartCoroutine(ShootGrapplingHook());
        }
    }

    private IEnumerator ShootGrapplingHook()
    {
        Grappling = true;
        PauseRigidbody(m_Rigidbody, true);
        m_WallStick.isPaused = true;
        m_PlayerMovement.freezeInput = true;

        if (Physics.Raycast(m_Camera.position, m_Camera.forward, out RaycastHit hitInfo, m_MaxGrappleDistance, m_GrappleLayers))
        {
            m_GrappleLoc = hitInfo.point;

            yield return new WaitForSeconds(m_GrappleTime);

            float maxPosition = m_GrappleLoc.y < m_Player.transform.position.y ? 
                m_GrappleHeight : 
                m_GrappleLoc.y + m_GrappleHeight;
            JumpToPosition(m_GrappleLoc, maxPosition);

            yield return new WaitForSeconds(m_EndGrapple);
        }

        m_PlayerMovement.freezeInput = true;
        m_WallStick.isPaused = false;
        PauseRigidbody(m_Rigidbody, false);
        yield return new WaitForSeconds(m_GrappleCooldown);
        Grappling = false;
    }

    private void PauseRigidbody(Rigidbody rigidbody, bool pause)
    {
        rigidbody.linearVelocity = Vector3.zero;
    }

    private void JumpToPosition(Vector3 target, float currentHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = target.y - m_Player.transform.position.y;
        Vector3 displacementXZ = new Vector3(target.x - m_Player.transform.position.x, 0f, target.z - m_Player.transform.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * currentHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * currentHeight / gravity) + Mathf.Sqrt(2 * displacementY / gravity));

        m_Rigidbody.linearVelocity = velocityXZ + velocityY;
    }
}
