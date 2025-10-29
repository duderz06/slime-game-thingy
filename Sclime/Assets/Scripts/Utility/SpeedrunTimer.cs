using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    public bool DoTimer = false;
    private bool Done = false;

    public GameObject TimerObj;

    public TextMeshProUGUI TimerText;

    public float timer = 0f;

    void Start()
    {
        if (DoTimer)
        {

            TimerObj.SetActive(true);

        }
        else 
        {

            TimerObj.SetActive(false);

        }
    }

    void Update()
    {
        if (DoTimer&&!Done) 
        {
            timer += Time.deltaTime;
            TimerText.text = System.Math.Round(timer, 3).ToString();
        }
    }

    public void StopTimer() 
    {
        Done=true;
    }
}
