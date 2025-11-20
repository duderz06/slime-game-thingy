using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizationHolder : MonoBehaviour
{

 

    public List<Material> Mats = new List<Material>();
    public List<GameObject> Hats = new List<GameObject>();

    public static int MatChosen = 0;
    public static int HatChosen = 0;


    public static Color ParticleColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        

        if (HatChosen > 0)
        {
            GameObject PlayerHatHolder = GameObject.Find("Hat Holder");

            GameObject madehat = Instantiate(Hats[HatChosen]);

            madehat.transform.SetParent(PlayerHatHolder.transform);
            madehat.transform.localPosition = Hats[HatChosen].transform.position;
            madehat.transform.localRotation = Hats[HatChosen].transform.rotation;

        }

        if (MatChosen > 0)
        {
            Renderer PlayerMatHolder = GameObject.Find("Player Slime").GetComponent<Renderer>();


            PlayerMatHolder.material = Mats[MatChosen];

            StateHandler sh = FindObjectOfType<StateHandler>();

            sh.StickMat = Mats[MatChosen];

            ParticleSystem SlimeParticles = GameObject.Find("slime particles").GetComponent<ParticleSystem>();
            

        }

    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
