using System.Collections.Generic;
using UnityEngine;

public class CollectablesHandler : MonoBehaviour
{
    public List<Transform> Slimes = new List<Transform>();
    public List<bool> Gotten = new List<bool>();
    public List<SpriteRenderer> ImagesHolder = new List<SpriteRenderer>();
    public List<Sprite> Images = new List<Sprite>();

    public Sprite EmptySprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for (int i = 0; i < Slimes.Count; i++) {

            if (Gotten[i])
            {

                Slimes[i].gameObject.SetActive(true);

                ImagesHolder[i].sprite = Images[i];

            }
            else {
                Slimes[i].gameObject.SetActive(false);

                ImagesHolder[i].sprite = EmptySprite;

            }


        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
