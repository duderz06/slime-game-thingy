using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HubTeleport : MonoBehaviour
{

    public GameObject Player;

    public Transform TeleportLocation;

    private Image FadeOutImage;

    public float FadeSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        FadeOutImage = GameObject.Find("fadeout black").GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player")) { 
            StartCoroutine("Teleport");
        
        
        }


        
    }


    public IEnumerator Teleport()
    {


        while (FadeOutImage.color.a < 1f)
        {
            Color appearing = FadeOutImage.color;

            appearing.a += FadeSpeed * Time.deltaTime;

            FadeOutImage.color = appearing;



            yield return null;

        }


        Color full = FadeOutImage.color;
        full.a = 1f;

        FadeOutImage.color = full;



        Player.transform.position = TeleportLocation.position;


        while (FadeOutImage.color.a > 0f)
        {

            Color fading = FadeOutImage.color;
            fading.a -= FadeSpeed * Time.deltaTime;
            FadeOutImage.color = fading;


            yield return null;


        }


        Color gone = FadeOutImage.color;

        gone.a = 0f;

        FadeOutImage.color = gone;


    }


}
