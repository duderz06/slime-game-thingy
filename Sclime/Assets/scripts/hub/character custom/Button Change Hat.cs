using NUnit.Framework;
using UnityEngine;

public class ButtonChangeHat : MonoBehaviour
{

    public GameObject hat;
    public GameObject PlayerHatHolder;

   


    public void OnMouseDown() {




        foreach (Transform child in PlayerHatHolder.transform)
        {

            Destroy(child.gameObject);

        }


        if (hat != null)
        {
            GameObject madehat = Instantiate(hat);

            madehat.transform.SetParent(PlayerHatHolder.transform);
            madehat.transform.localPosition = hat.transform.position;
            madehat.transform.localRotation = hat.transform.rotation;
        }

    }


}
