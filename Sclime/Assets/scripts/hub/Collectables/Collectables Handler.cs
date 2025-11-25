using System.Collections.Generic;
using UnityEngine;

public class CollectablesHandler : MonoBehaviour
{
    public List<Transform> Slimes = new List<Transform>();
    public List<SpriteRenderer> ImagesHolder = new List<SpriteRenderer>();
    public List<Sprite> Images = new List<Sprite>();
    public List<Sprite> EmptySprites = new List<Sprite>();

    
    
    private string collectibleid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {



        for (int i = 0; i < Slimes.Count; i++) {

            collectibleid = i.ToString();

            bool iscollected = SlimeFriendTXTreader.Get(collectibleid) == 1;


            if (iscollected)
            {

                Slimes[i].gameObject.SetActive(true);

                ImagesHolder[i].sprite = Images[i];

            }
            else {
                Slimes[i].gameObject.SetActive(false);

                ImagesHolder[i].sprite = EmptySprites[i];

            }


        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
