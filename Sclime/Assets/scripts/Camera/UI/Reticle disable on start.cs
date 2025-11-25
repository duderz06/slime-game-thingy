using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Reticledisableonstart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject Reticle = GameObject.Find("reticle");

        Reticle.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
