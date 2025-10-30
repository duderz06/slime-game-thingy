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
    private RectTransform Buttons;
    public float LevelWipeSpeed=3f;


    void Start() {

        ST = FindFirstObjectByType<SpeedrunTimer>();
        LevelWipe = GameObject.Find("Level Wipe").GetComponent<RectTransform>();
        Buttons = GameObject.Find("Buttons").GetComponent<RectTransform>();
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


        StartCoroutine("ButtonsUp");


    }

    public IEnumerator ButtonsUp() {


        Vector2 TargPos = new Vector2(0, -185);


        while (Vector2.Distance(Buttons.anchoredPosition, TargPos) > 0.1f)
        {

            Buttons.anchoredPosition = Vector2.Lerp(Buttons.anchoredPosition, TargPos, LevelWipeSpeed * Time.deltaTime);

            yield return null;

        }

        Buttons.anchoredPosition = TargPos;


    }


   



}
