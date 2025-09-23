using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerWallStick wallStick;
    private void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        if (direction != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(direction);
        }

        if (direction.magnitude > 0)
        {
            wallStick.rot = transform.localRotation;
            wallStick.isMoving = true;
        }
        else
        {
            wallStick.isMoving = false;
        }
    }
}

