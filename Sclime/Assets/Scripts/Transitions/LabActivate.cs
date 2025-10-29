using UnityEngine;
using System.Collections;

public class LabActivate : MonoBehaviour
{

    private bool PlayerActivated=false;
    public bool LabOn=false;

    public GameObject DarknessOverlay;
    public GameObject LabStuff;


    public AudioSource SpeakerAudioSource;
    public AudioClip PlayerSeenSfx;


    void Update()
    {


        DarknessOverlay.SetActive(!LabOn);
        LabStuff.SetActive(LabOn);






    }




    public void OnTriggerEnter(Collider col) {


        if (col.gameObject.CompareTag("Player")&&!PlayerActivated) {

            PlayerActivated=true;
            StartCoroutine("LabStartUp");
        
        
        }
    
    }

    public IEnumerator LabStartUp() {


        int goes = 0;
        float timer = 0f;

        while (goes < 4) {

            timer += Time.deltaTime;

            if (timer >= 0.2f) {

                timer = 0f;
                LabOn = !LabOn;
                goes++;
            
            }
        
        
            yield return null;
        }

        SpeakerAudioSource.PlayOneShot(PlayerSeenSfx, 1f);


        yield return new WaitForSeconds(1f);

        LabOn = true;

        yield return new WaitForSeconds(0.25f);


        Destroy(gameObject);

    }


}
