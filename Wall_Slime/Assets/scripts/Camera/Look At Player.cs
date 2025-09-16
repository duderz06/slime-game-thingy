using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    private GameObject player;

    public bool off = false;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");

        if (player == null) {

            Debug.LogWarning("cam cant find player");
        
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!off)
        {
            if (player != null)
            {

                transform.LookAt(player.transform);


            }

        }

    }



}
