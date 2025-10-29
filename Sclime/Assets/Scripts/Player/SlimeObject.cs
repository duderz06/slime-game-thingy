using UnityEngine;

public class SlimeObject : MonoBehaviour
{
    public enum SlimeType
    {
        None,
        Stick,
        Bounce
    }

    public SlimeType slimeType = SlimeType.None;
    private new Rigidbody rigidbody;
    private new Collider collider;

    [Header("Stick")]
    private GameObject stickedObject = null;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    public void SetState(SlimeType type)
    {
        if (slimeType == type) return; //no change needed

        slimeType = type;

        switch (slimeType)
        {
            case SlimeType.None: //resets to normal physics
                collider.material.bounciness = 0f;
                rigidbody.isKinematic = false;
                stickedObject = null;
                break;
            case SlimeType.Stick:
                collider.material.bounciness = 0f;
                rigidbody.isKinematic = false;
                break;
            case SlimeType.Bounce:
                collider.material.bounciness = 1f;
                rigidbody.isKinematic = false;
                stickedObject = null;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (slimeType == SlimeType.Stick)
        {
            if (!collision.gameObject.CompareTag("Player") && stickedObject == null)
            {
                stickedObject = collision.gameObject;

                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                    fixedJoint.connectedBody = rb;
                }
                else
                {
                    transform.SetParent(collision.transform);
                    rigidbody.isKinematic = true;
                }
            }
        }
    }
}
