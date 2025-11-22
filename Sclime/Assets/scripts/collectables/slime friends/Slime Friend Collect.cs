using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeFriendCollect : MonoBehaviour
{

    public string collectibleid;
    private bool iscollected = false;


    public GameObject Object;
    private List<GameObject> AllChildren = new List<GameObject>();

    public Material collectedmat;



    void Start()
    {

        iscollected = SlimeFriendTXTreader.Get(collectibleid) == 1;

        if (iscollected)
        {
            Object.GetComponent<Renderer>().material = collectedmat;

            foreach (Renderer renderer in Object.GetComponentsInChildren<Renderer>())
            {
                renderer.material = collectedmat;

            }


        }

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") )
        {
            Collect();

        }

    }

    public void Collect()
    {

        SlimeFriendTXTreader.Set(collectibleid, 1);

        iscollected = true;

        Destroy(Object);

    }


}


