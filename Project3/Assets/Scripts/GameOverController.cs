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
        CustomPointer.TogglePause();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit(); //Works when built
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
