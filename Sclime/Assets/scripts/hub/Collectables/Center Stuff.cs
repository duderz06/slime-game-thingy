using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CenterStuff : MonoBehaviour
{

    public float Distance = 1f;

    private Vector3 StartPos;

    private List<Transform> Stuff = new List<Transform>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 StartPos = transform.position;

        //put all children of this object into the stuff list
        //center their position on the x axis in a line based on startpos and distance

        for (int i = 0; i < transform.childCount; i++)
        {

            Stuff.Add(transform.GetChild(i));


        }

        float width = (Stuff.Count - 1) * Distance;

        float z = StartPos.z - width / 2f;


        for (int i = 0; i < Stuff.Count; i++)
        {
            Vector3 pos = new Vector3(0f, 0f, z + i * Distance);
            Stuff[i].localPosition = pos;


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
