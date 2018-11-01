using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit(); //Works when built
    }
}
