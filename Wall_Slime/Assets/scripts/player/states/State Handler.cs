using UnityEngine;
using UnityEngine.UI;

public class StateHandler : MonoBehaviour
{

    public bool Stick = true;

    public Sprite StickSprite;
    public Sprite BounceSprite;

    public Image StateImg;

    public Rigidbody rb;

    public PlayerMovement PM;
    public PlayerWallStick PWS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Stick)
        {

            StateImg.sprite = StickSprite;

        }

        else {


            StateImg.sprite = BounceSprite;

        }


        // make so you cant do it in the air
        if (Input.GetKeyDown(KeyCode.Space)) {


            Stick = !Stick;
        
        }


        rb.useGravity = !Stick;

        PM.enabled = Stick;
        PWS.enabled = Stick;

    }



}
