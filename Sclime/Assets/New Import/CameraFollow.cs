using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float speed = 0.2f;


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
        float rotTimer = 0f;
        if (transform.rotation != target.rotation)
        {
            rotTimer += Time.deltaTime * speed;
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotTimer);
        }
        else
        {
            rotTimer = 0;
        }

        float posTimer = 0f;
        if (transform.position != target.position)
        {
            posTimer += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(transform.position, target.position, posTimer);
        }
        else
        {
            posTimer = 0;
        }
    }
}