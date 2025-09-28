using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerWallStick wallStick;
    public Transform rotationReader;

    private void Start()
    {
        wallStick = GetComponentInChildren<PlayerWallStick>();
    }

    private void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        if (direction != Vector3.zero)
        {
            rotationReader.localRotation = Quaternion.LookRotation(direction);
        }

        if (direction.magnitude > 0)
        {
            wallStick.rot = rotationReader.localRotation;
            wallStick.isMoving = true;
        }
        else
        {
            wallStick.isMoving = false;
        }
    }
}

