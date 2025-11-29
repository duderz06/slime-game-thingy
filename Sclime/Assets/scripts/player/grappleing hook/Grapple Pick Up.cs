using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrapplePickUp : MonoBehaviour
{

    public Transform Cam;
    private GrappleHookShoot GHS;

    public Transform Player;


    public float PullSpeed = 10f;


    private GameObject Obj;
    private Rigidbody rb;

    private bool BufferStop=false;
    private bool ForcedStop = false;

    private GameObject HookShow;
    private GameObject MadeHook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GHS = FindObjectOfType<GrappleHookShoot>();
        HookShow = GameObject.Find("grapple hook");

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void PullObjectStart(GameObject obj)
    {


        Obj = obj;
        rb = Obj.GetComponent<Rigidbody>();
        MadeHook = Instantiate(HookShow, transform.position, transform.rotation);

        GHS.GrappelingItem = true;
        StartCoroutine(PullObject());

    }

    public void PullObjectStop(bool forced)
    {

        BufferStop = true;
        ForcedStop = forced;

    }


    public IEnumerator PullObject(){



        while (Vector3.Distance(Obj.transform.position, Player.transform.position) > 1) {

            if (BufferStop) {

                
                break;
            

            }

            Vector3 dir = Player.transform.position - Obj.transform.position;

            float Distance = dir.magnitude;

            rb.linearVelocity = dir.normalized * PullSpeed;

            yield return null;

            MadeHook.transform.LookAt(Obj.transform.position, Vector3.left);

            MadeHook.transform.position = (Player.position + Obj.transform.position) / 2f;

            MadeHook.transform.localScale = new Vector3(MadeHook.transform.localScale.x, MadeHook.transform.localScale.y, Distance);
        }

        if (!ForcedStop)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        GHS.GrappelingItem = false;

        ForcedStop = false;
        BufferStop = false;

        Destroy(MadeHook);


    }




}
