using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerWallStick wallStick;
    public Transform rotationReader;

    [HideInInspector] public bool freezeInput = false;

    private void Start()
    {
        wallStick = GetComponentInChildren<PlayerWallStick>();
    }

    private void Update()
    {
        if (freezeInput) return;

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new(horizontal, 0f, vertical);
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

