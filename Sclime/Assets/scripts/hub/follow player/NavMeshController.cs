using UnityEngine;
using UnityEngine.UI;

public class NavMeshController : MonoBehaviour
{
    
    public GameObject Target;
    private UnityEngine.AI.NavMeshAgent agent;

    bool walking = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        

    }



    // Update is called once per frame
    void Update()
    {

        if (walking)
        {
            agent.destination = Target.transform.position;
        }
        else {

            agent.destination = transform.position;

        }


    }


}
