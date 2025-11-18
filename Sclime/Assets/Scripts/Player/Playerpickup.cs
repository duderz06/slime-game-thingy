using UnityEngine;

public class Playerpickup : MonoBehaviour
{
    private GameObject heldObject = null;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private float pickupDistance = 1f;
    [SerializeField] private float dropCheckRadius = 0.25f;
    [SerializeField] private LayerMask obstacleLayers = ~0;
    private LayerMask originalLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
                {
                    if (hit.collider.CompareTag("Pickupable"))
                    {
                        heldObject = hit.collider.gameObject;
                        heldObject.transform.SetParent(holdPoint);
                        heldObject.transform.localPosition = Vector3.zero;
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                        heldObject.layer = LayerMask.NameToLayer("HeldObject");
                    }
                }
            }
            else
            {
                // Calculate desired drop position in front of player
                Vector3 dropPos = transform.position + transform.forward * (pickupDistance) + (transform.up * 0.5f);

                // Check for obstacles at the drop position using an overlap sphere
                Collider[] overlaps = Physics.OverlapSphere(dropPos, dropCheckRadius, obstacleLayers, QueryTriggerInteraction.Ignore);

                bool blocked = false;
                if (overlaps != null && overlaps.Length > 0)
                {
                    foreach (var col in overlaps)
                    {
                        if (col != null && heldObject != null && col.gameObject != heldObject)
                        {
                            // Found another collider in the drop area that's not the held object -> blocked
                            blocked = true;
                            break;
                        }
                    }
                }

                if (!blocked)
                {
                    // Additionally check with a raycast to ensure no obstacles directly in front
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance / 1.5f, obstacleLayers))
                    {
                        blocked = true;
                    }
                }

                if (!blocked)
                {
                    heldObject.GetComponent<Rigidbody>().isKinematic = false;
                    heldObject.layer = LayerMask.NameToLayer("Default");
                    heldObject.transform.SetParent(null);
                    heldObject.transform.position = dropPos;
                    heldObject = null;
                }
            }
        }
    }
}
