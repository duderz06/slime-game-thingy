using UnityEngine;

public class CameraClip : MonoBehaviour
{
    public Transform player;
    public LayerMask groundLayer;
    public float maxDistance = 10f;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = transform.position - player.position;
        if (Physics.Raycast(player.position, dir.normalized, out hit, maxDistance, groundLayer))
        {
            transform.position = hit.point - (dir.normalized * 0.5f);
        }
    }
}
