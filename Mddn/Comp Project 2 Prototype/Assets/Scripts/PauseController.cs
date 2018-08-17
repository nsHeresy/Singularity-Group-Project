using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    public static bool isGamePaused;
    public GameObject pauseMenuUI;

    private void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (isGamePaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }

    }

    void Pause()
    {
        pauseMenuUI.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
        isGamePaused = true;
        CustomPointer.TogglePause();
    }

    public void Resume()
    {
        pauseMenuUI.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
        isGamePaused = false;
        CustomPointer.TogglePause();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
