using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSelect : MonoBehaviour
{

    public string SceneToGoTo = null;


    public void OnMouseDown() {

        SceneManager.LoadScene(SceneToGoTo);


    }


}
