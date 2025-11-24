using UnityEngine;

public class GrappleHookShoot : MonoBehaviour
{

    public Transform Cam;
    private GrappleHookAim GHA;
    private PlayerWallStick PWS;

    public float GrappleRange = 100f;

    public LayerMask Stickable;

    public Transform Player;
    private Rigidbody rb;

    private bool grappling = false;
    public float PullStrength=15f;

    private Vector3 PullPoint = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GHA = FindObjectOfType<GrappleHookAim>();
        PWS = FindObjectOfType<PlayerWallStick>();
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)&&GHA.Aiming)
        {

            if (!grappling)
            {
                RaycastHit hit;


                if (Physics.Raycast(Cam.position, Cam.forward, out hit, GrappleRange, Stickable))
                {

                    PullPoint = hit.point;
                    grappling = true;

                }
            }
            else {

                grappling = false;

            }


        }

        else if (Input.GetMouseButtonDown(0) && grappling)
        {

            grappling = false;


        }



        if (grappling) {

            Vector3 dir;

            dir = PullPoint - Player.position;



            rb.linearVelocity = (dir.normalized * PullStrength);

            if (Vector3.Distance(Player.position, PullPoint) < 0.15) {

                grappling = false;
            
            }

        }



        PWS.enabled = !grappling;
        Debug.Log(!grappling);

    }


}
