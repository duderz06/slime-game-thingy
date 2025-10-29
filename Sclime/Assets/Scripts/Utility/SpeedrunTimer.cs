using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{

    public bool DoTimer=false;
    private bool Done=false;

    public GameObject TimerObj;

    public TextMeshProUGUI TimerText;

    public float timer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (DoTimer)
        {

            TimerObj.SetActive(true);

        }
        else {

            TimerObj.SetActive(false);

        }


    }

    // Update is called once per frame
    void Update()
    {

        if (DoTimer&&!Done) {

            timer += Time.deltaTime;
            TimerText.text = timer.ToString();

        
        }




    }



    public void StopTimer() {



        Done=true;



    }

}
