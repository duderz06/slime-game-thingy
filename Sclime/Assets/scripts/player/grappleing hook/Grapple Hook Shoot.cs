using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GrappleHookShoot : MonoBehaviour
{

    public Transform Cam;
    private GrappleHookAim GHA;
    private GrapplePickUp GPU;
    private PlayerWallStick PWS;
    private StateHandler SH;

    public bool GrappelingItem = false;

    public float GrappleRange = 100f;

    public LayerMask Stickable;

    public Transform Player;
    private Rigidbody rb;

    private bool grappling = false;
    public float PullStrength=15f;

    private Vector3 PullPoint = Vector3.zero;


    private GameObject HookShow;
    private GameObject MadeHook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //Cam = transform.Find("Main Camera");
        HookShow = GameObject.Find("grapple hook");

        GHA = FindObjectOfType<GrappleHookAim>();
        GPU = FindObjectOfType<GrapplePickUp>();
        PWS = FindObjectOfType<PlayerWallStick>();
        SH = FindObjectOfType<StateHandler>();

        rb = Player.GetComponent<Rigidbody>();

        SH.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)&&GHA.Aiming)
        {
            
            if (!grappling && !GrappelingItem)
            {
                RaycastHit hit;

                if (Physics.Raycast(Cam.position, Cam.forward, out hit, GrappleRange))
                {


                    if (hit.collider.CompareTag("Pickupable"))
                    {
                        GPU.PullObjectStart(hit.collider.gameObject);

                    }

                    if ((Stickable.value & (1 << hit.collider.gameObject.layer)) != 0)
                    {



                        PullPoint = hit.point;

                        grappling = true;
                        rb.linearVelocity = Vector3.zero;

                        MadeHook = Instantiate(HookShow, transform.position, transform.rotation);


                        Player.rotation = Quaternion.identity;

                        PWS.grounded = false;

                    }

                }
               

            }
            else if (grappling)
            {

                grappling = false;
                Destroy(MadeHook);

            }

            else if (GrappelingItem) {

                GPU.PullObjectStop(true);


            }


        }

        else if (Input.GetMouseButtonDown(0) && grappling)
        {

            grappling = false;
            Destroy(MadeHook);


        }







        PWS.enabled = !grappling;

    }

    void FixedUpdate()
    {
        if (grappling)
        {

            Vector3 dir = PullPoint - Player.position;

            float Distance = dir.magnitude;
            float MoveDistance = PullStrength * Time.deltaTime;


            MadeHook.transform.LookAt(PullPoint, Vector3.left);
           
            MadeHook.transform.position = (Player.position+PullPoint)/2f;

            MadeHook.transform.localScale = new Vector3(MadeHook.transform.localScale.x, MadeHook.transform.localScale.y, Distance);

            if (MoveDistance >= Distance)
            {

                rb.position = PullPoint;
                rb.linearVelocity = Vector3.zero;

                grappling = false;
                Destroy(MadeHook);

            }


            else
            {
                rb.linearVelocity = dir.normalized * PullStrength;

            }

        }



    }
}
