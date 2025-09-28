using UnityEngine;
using UnityEngine.UI;

public class StateHandler : MonoBehaviour
{
    public bool Stick = true;

    public Sprite StickSprite;
    public Sprite BounceSprite;

    public Image StateImg;

    public PlayerWallStick PWS;

    void Update()
    {
        // if (Stick)
        // {
        //     StateImg.sprite = StickSprite;
        // }

        // else
        // {
        //     StateImg.sprite = BounceSprite;
        // }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stick = !Stick;
            PWS.SwapState(Stick);
        }
    }
}
