using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class EndLevel : MonoBehaviour
{

    private bool HasEnded = false;

    private SpeedrunTimer ST;
    private TextMeshProUGUI ResultTime;


    private RectTransform LevelWipe;
    private RectTransform LevelSelectButton;
    public float LevelWipeSpeed=3f;


    void Start() {

        ST = FindObjectOfType<SpeedrunTimer>();
        LevelWipe = GameObject.Find("Level Wipe").GetComponent<RectTransform>();
        LevelSelectButton = GameObject.Find("Level Select Button").GetComponent<RectTransform>();
        ResultTime = GameObject.Find("Result Time").GetComponent<TextMeshProUGUI>();
    
    }

    public void EndTheLevel() {

        HasEnded = true;

        if (ST != null) {

            if (ST.DoTimer)
            {
                ST.StopTimer();

                ResultTime.text = ST.timer + "";
            }
        }

        StartCoroutine("LevelWipeToCenter");





    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&!HasEnded) EndTheLevel();

    }




    public IEnumerator LevelWipeToCenter()
    {
        Vector2 TargPos = Vector2.zero;


        while (Vector2.Distance(LevelWipe.anchoredPosition, TargPos) > 0.15f)
        {


            LevelWipe.anchoredPosition = Vector2.Lerp(LevelWipe.anchoredPosition, TargPos, LevelWipeSpeed * Time.deltaTime );

            yield return null;

        }

        LevelWipe.anchoredPosition = TargPos;


        StartCoroutine("LevelSelectButtonUp");

    }

    public IEnumerator LevelSelectButtonUp() {


        Vector2 TargPos = new Vector2(250,-170);


        while (Vector2.Distance(LevelSelectButton.anchoredPosition, TargPos) > 0.1f)
        {


            LevelSelectButton.anchoredPosition = Vector2.Lerp(LevelSelectButton.anchoredPosition, TargPos, LevelWipeSpeed * Time.deltaTime);

            yield return null;

        }

        LevelSelectButton.anchoredPosition = TargPos;


    }


    


}
