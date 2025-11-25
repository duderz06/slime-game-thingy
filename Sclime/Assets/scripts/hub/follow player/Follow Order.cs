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
            //&& child.name.StartsWith("slime follower")
            if (child.gameObject.activeInHierarchy )
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

                    nav.Target = Followers[i - 1].transform.Find("follower target").gameObject;

                }


            }
        }







    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
