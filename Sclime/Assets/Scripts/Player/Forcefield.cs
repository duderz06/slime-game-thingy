using UnityEngine;

public class Forcefield : MonoBehaviour
{
    [SerializeField] private GameObject[] walls;
    [SerializeField] private bool reverse;

    public void Activate()
    {
        if (!reverse)
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
        }

    }

    public void Deactivate()
    {
        if (!reverse)
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(true);
            }
        }
    }
}
