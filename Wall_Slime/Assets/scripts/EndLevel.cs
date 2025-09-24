using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) winScreen.SetActive(true);

    }
}
