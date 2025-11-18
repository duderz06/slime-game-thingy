using UnityEngine;
using UnityEngine.UI;

public class StateHandler : MonoBehaviour
{
    public bool Stick = true;

    public Sprite StickSprite;
    public Sprite BounceSprite;

    private Image StateImg;

    public PlayerWallStick PWS;

    public Material StickMat;
    public Material BounceMat;

    public GameObject Player;
    public Renderer PlayerMat;

    public ParticleSystem SlimePart;
    public Color StickPartColor;
    public Color BouncePartColor;

    void Start() {

        StateImg = GameObject.Find("state image").GetComponent<Image>();


    }

    void Update()
    {
        var SlimePartMain = SlimePart.main;




        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stick = !Stick;
            PWS.SwapState(Stick);
            SwapState();
        }
    }

    public void SwapState() {

        var SlimePartMain = SlimePart.main;

        if (Stick)
        {
            StateImg.sprite = StickSprite;
            PlayerMat.material = StickMat;
            SlimePartMain.startColor = StickPartColor;
        }
        else
        {
            StateImg.sprite = BounceSprite;
            PlayerMat.material = BounceMat;
            SlimePartMain.startColor = BouncePartColor;
        }


    }


}
