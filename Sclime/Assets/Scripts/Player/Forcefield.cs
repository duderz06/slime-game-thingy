using UnityEngine;

public class Forcefield : MonoBehaviour
{
    private GameObject[] walls;

    public void Activate()
    {
        foreach (GameObject wall in walls)
        {
            wall.SetActive(true);
        }
    }

    public void Deactivate()
    {
        foreach (GameObject wall in walls)
        {
            wall.SetActive(false);
        }
    }
}
