using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static bool IsGamePaused;
    public GameObject PauseMenuUi;

    private void Start()
    {
        Resume();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (IsGamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
        CustomPointer.TogglePause();
    }

    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        CustomPointer.TogglePause();       
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit(); //Works when built
    }
}