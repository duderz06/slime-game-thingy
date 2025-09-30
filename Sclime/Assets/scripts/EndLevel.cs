using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class EndLevel : MonoBehaviour
{

    private bool HasEnded = false;

    private SpeedrunTimer ST;
    private TextMeshProUGUI ResultTime;


    private RectTransform LevelWipe;
    private RectTransform LevelSelectButton;
    private RectTransform nextLevelButton;
    public float LevelWipeSpeed=3f;


    void Start() {

        ST = FindFirstObjectByType<SpeedrunTimer>();
        LevelWipe = GameObject.Find("Level Wipe").GetComponent<RectTransform>();
        LevelSelectButton = GameObject.Find("LEVEL SELECT").GetComponent<RectTransform>();
        nextLevelButton = GameObject.Find("NEXT LEVEL").GetComponent<RectTransform>();
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        Vector2 TargPos2 = new Vector2(-290, -185);


        while (Vector2.Distance(LevelSelectButton.anchoredPosition, TargPos2) > 0.1f && Vector2.Distance(nextLevelButton.anchoredPosition, TargPos) > 0.1f)
        {

            nextLevelButton.anchoredPosition = Vector2.Lerp(LevelSelectButton.anchoredPosition, TargPos, LevelWipeSpeed * Time.deltaTime);
            LevelSelectButton.anchoredPosition = Vector2.Lerp(LevelSelectButton.anchoredPosition, TargPos2, LevelWipeSpeed * Time.deltaTime);

            yield return null;

        }

        nextLevelButton.anchoredPosition = TargPos;
        LevelSelectButton.anchoredPosition = TargPos2;


    }


    


}
