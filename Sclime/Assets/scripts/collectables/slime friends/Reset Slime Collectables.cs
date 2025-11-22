using UnityEngine;

public class ResetSlimeCollectables : MonoBehaviour
{

    public bool Delete = false;

    void Awake()
    {

        if (Delete) {

            SlimeFriendTXTreader.ResetAll();



        }


    }

   
}
    