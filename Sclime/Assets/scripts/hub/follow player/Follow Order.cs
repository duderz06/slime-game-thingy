using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FollowOrder : MonoBehaviour
{

    public List<GameObject> Followers = new List<GameObject>();


    public GameObject PlayerFollowTarget;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

      
        Followers.Clear();


        foreach (Transform child in transform)
        {

            if (child.gameObject.activeInHierarchy && child.name.StartsWith("slime follower"))
            {

                Followers.Add(child.gameObject);


            }



        }



        for (int i = 0; i < Followers.Count; i++)
        {


            var nav = Followers[i].GetComponent<NavMeshController>();


            if (nav != null)
            {


                if (i == 0)
                {

                    nav.Target = PlayerFollowTarget;
                }


                else
                {
                    nav.Target = Followers[i - 1];

                }


            }
        }







    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
