using UnityEngine;

public class CameraLookAtObj : MonoBehaviour
{
    public Transform Obj;

    void Update()
    {
        if (Obj != null)
        {
            Vector3 dir = (Obj.position - transform.position).normalized;

            transform.forward = dir;
        }
    }
}
