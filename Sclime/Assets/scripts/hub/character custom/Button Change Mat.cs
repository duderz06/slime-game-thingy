using UnityEngine;

public class ButtonChangeMat : MonoBehaviour
{

    public Material mat;
    public Renderer PlayerMat;
    public ParticleSystem ParticleSystem;
    public Color ParticleColour;
    public int MatInList = 0;

    private StateHandler SH;


    void Start() {




        SH = FindObjectOfType < StateHandler > ();
    
    
    
    
    }

    public void OnMouseDown() {

   
        PlayerMat.material = mat;
        SH.StickMat = mat;

        var ParticleMainThing = ParticleSystem.main;
        ParticleMainThing.startColor = ParticleColour;

        PlayerCustomizationHolder.MatChosen = MatInList;
        PlayerCustomizationHolder.ParticleColor = ParticleColour;

    }


}
