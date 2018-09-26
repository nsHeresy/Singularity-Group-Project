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

    /// <summary>
    /// Pauses the game. Enables the pause UI, freeses time, and releases the cursor from the customPointer.
    /// </summary>
    void Pause()
    {
        pauseMenuUI.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
        isGamePaused = true;
        CustomPointer.TogglePause();
    }

    /// <summary>
    /// Unpauses the game. Disaables the pause UI, unfreezes time, and gives the cursor to the customPointer.
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
        isGamePaused = false;
        CustomPointer.TogglePause();
    }

    /// <summary>
    /// Reloads the game level
    /// </summary>
    public void ResetLevel()
    {
        SceneManager.LoadScene("GameLevel");
    }
    
    /// <summary>
    /// Loads the main menu level
    /// </summary>
    public void QuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
