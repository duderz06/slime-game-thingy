using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 0.2f;
    public float rotSpeed = 0.2f;


    private void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target was not properly initialized.");
            target = FindAnyObjectByType<PlayerLook>().transform;
        }
    }

    private void LateUpdate()
    {
        if (transform.rotation != target.rotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * rotSpeed);
        }

        if (transform.position != target.position)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed);
        }
    }
}