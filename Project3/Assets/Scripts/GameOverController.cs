using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
    
    public GameObject gameOverUI;

    public void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void gameover()
    {
        gameOverUI.SetActive(true);
        //CustomPointer.TogglePause();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.UnloadSceneAsync("GameLevel");
        SceneManager.LoadScene("GameLevel");
    }
}
