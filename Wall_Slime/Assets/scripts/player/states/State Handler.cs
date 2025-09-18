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
    public BouncePlayerMovement BPM;

    private RaycastHit hit;
    public LayerMask groundLayer;
    public float groundedLength = 1f;


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

        //Debug.DrawLine(transform.position, -transform.up * groundedLength, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position,-transform.up , out hit, groundedLength, groundLayer)) {


            Stick = !Stick;
        
        }



        rb.useGravity = !Stick;
        BPM.enabled = !Stick;


        PM.enabled = Stick;
        PWS.enabled = Stick;

    }



}
