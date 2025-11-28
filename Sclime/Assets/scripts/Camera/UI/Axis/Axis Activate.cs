using UnityEngine;

public class AxisActivate : MonoBehaviour
{

    public int SetActiveInpsector = 0;
    public static int Active = 0;
    public GameObject Axis;
    public GameObject Arrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //delete when option menu added
        if (Active != SetActiveInpsector) { 
        
            Active = SetActiveInpsector;
        
        }

        if (Active == 0)
        {

            Axis.SetActive(false);
            Arrow.SetActive(false);

        }

        else if (Active == 1) {

            Axis.SetActive(true);
            Arrow.SetActive(false);
        }

        else if (Active == 2)
        {

            Axis.SetActive(false);
            Arrow.SetActive(true);
        }
    }
}
