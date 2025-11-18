using NUnit.Framework;
using UnityEngine;

public class ButtonChangeHat : MonoBehaviour
{

    public GameObject hat;
    public int HatInList = 0;

   
    public void OnMouseDown() {

        PlayerCustomizationHolder.HatChosen = HatInList;

        GameObject PlayerHatHolder = GameObject.Find("Hat Holder");


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

            //madehat.transform.localPosition = Vector3.zero;
            //madehat.transform.localRotation = Quaternion.identity;


        }

    }


}
