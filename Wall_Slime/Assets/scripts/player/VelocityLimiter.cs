using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VelocityLimiter : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float maxVelocity = 20f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        rigidbody.linearVelocity = new Vector3(
            Mathf.Clamp(rigidbody.linearVelocity.x, -maxVelocity, maxVelocity),
            Mathf.Clamp(rigidbody.linearVelocity.y, -maxVelocity * 2f, maxVelocity * 2f),
            Mathf.Clamp(rigidbody.linearVelocity.z, -maxVelocity, maxVelocity)
        );
    }
}
