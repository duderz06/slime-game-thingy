using UnityEngine;

public class CameraClip : MonoBehaviour
{
    public Transform player;
    public LayerMask groundLayer;

    private RaycastHit hit;

    private Vector3 defaultPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        defaultPos = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(player.position, transform.position, out hit, groundLayer))
        {

            transform.position = hit.point;

        }
        else
        {
            transform.localPosition = defaultPos;
        }
    }
}
