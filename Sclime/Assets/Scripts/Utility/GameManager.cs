using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isMainMenu;
    [SerializeField] private bool paused;

    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (!isMainMenu)
        {
            if (Input.GetKeyUp(KeyCode.Escape)) Pause();

            if (Input.GetKeyUp(KeyCode.R)) ResetLevel();
        }
    }

    public void Pause()
    {
        paused = !paused;
        //Debug.Log("Paused is " +  paused);
        
        if (paused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void ResetLevel() { SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single); }

    public void GoToMainMenu() { SceneManager.LoadScene("Main-Menu", LoadSceneMode.Single); }

    public void GoToLevelSelect() { SceneManager.LoadScene("Level-Select", LoadSceneMode.Single); }

    public void QuitGame() { Application.Quit(); Debug.Log("Player Quit"); }

    public void StartGame() { SceneManager.LoadScene(1, LoadSceneMode.Single); }

    public void LevelSelecter(int sceneToLoad) { SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single); }
    
    public void NextLevel() { SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single); }
}