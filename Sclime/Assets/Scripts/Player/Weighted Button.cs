using UnityEngine;

public class WeightedButton : MonoBehaviour
{
    [SerializeField] private GameObject[] connectedObjects;
    [SerializeField] private Renderer[] buttonRenderer;
    [SerializeField] private Color pressedColor = Color.green;
    [SerializeField] private Color unpressedColor = Color.red;

    private int touchingObjectCount = 0;

    private void Awake()
    {
        SetButtonColor(unpressedColor);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (touchingObjectCount == 0)
        {
            // Transition from no touch to touch
            SendMessageToConnectedObjects("Activate");
            SetButtonColor(pressedColor);
        }
        touchingObjectCount++;
    }

    private void OnTriggerExit(Collider collision)
    {
        touchingObjectCount--;
        if (touchingObjectCount <= 0)
        {
            touchingObjectCount = 0;
            // Transition from touch to no touch
            SendMessageToConnectedObjects("Deactivate");
            SetButtonColor(unpressedColor);
        }
    }

    private void SetButtonColor(Color color)
    {
        if (buttonRenderer != null)
        {
            foreach (Renderer render in buttonRenderer)
            {
                render.material.color = color;
            }
        }
    }

    private void SendMessageToConnectedObjects(string message)
    {
        foreach (GameObject obj in connectedObjects)
        {
            if (obj != null)
            {
                obj.SendMessage(message, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
