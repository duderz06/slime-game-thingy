using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{


	private bool LockCursor = true;

    public float Sensitivity {
		get { return m_Sensitivity; }
		set { m_Sensitivity = value; }
	}

	[Range(0.1f, 9f)][SerializeField] private float m_Sensitivity = 2f;
	[Range(0f, 90f)][SerializeField] private float yRotationLimit = 88f;
	[Range(0f, 90f)][SerializeField] private float rotSpeed = 1f;
	
	[SerializeField] private Transform raycaster;
	[SerializeField] private Transform parent;
	[SerializeField] private Transform target;
	[SerializeField] private Transform rotationHandler;

	Vector2 rotation = Vector2.zero;
	const string xAxis = "Mouse X";
	const string yAxis = "Mouse Y";

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; //makes cursor in middle of screen
        Cursor.visible = false; //hides cursor
    }

    private void Start()
    {
		parent.rotation = raycaster.rotation;
    }

    private void Update()
	{
		rotation.x += Input.GetAxis(xAxis) * m_Sensitivity;
		rotation.y += Input.GetAxis(yAxis) * m_Sensitivity;
		rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
		var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

		transform.localRotation = yQuat;
		parent.localRotation = xQuat;
		raycaster.localRotation = xQuat;
    }

    private void LateUpdate()
    {
		transform.position = target.position;
		
		if (target.rotation != rotationHandler.rotation)
        {
			rotationHandler.rotation = Quaternion.Slerp(rotationHandler.rotation, target.rotation, Time.deltaTime * rotSpeed);
		}
	}

    public void ToggleCursor() {

		LockCursor = !LockCursor;

		if (LockCursor)
		{
			Cursor.lockState = CursorLockMode.Locked; //makes cursor in middle of screen
			Cursor.visible = false; //hides cursor
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
    }
}