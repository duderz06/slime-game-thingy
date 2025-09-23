using UnityEngine;
using System.Collections;

public class CameraLerp : MonoBehaviour
{
    public Transform target;

    private float timer = 0;
    public float speed = 0.2f;

    private void LateUpdate()
    {
        transform.position = target.position;

        if (transform.rotation != target.rotation)
        {
            timer += Time.deltaTime * speed;
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, timer);
        }
        else
        {
            timer = 0;
        }
    }
}