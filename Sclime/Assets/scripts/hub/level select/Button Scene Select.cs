using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSelect : MonoBehaviour
{

    public string SceneToGoTo = null;


    public void OnMouseDown() {

        Debug.Log("Clicked object: " + gameObject.name);
        SceneManager.LoadScene(SceneToGoTo);


    }


}
