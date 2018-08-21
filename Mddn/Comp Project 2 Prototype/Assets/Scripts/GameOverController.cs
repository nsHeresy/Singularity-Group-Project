using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public Canvas UI;

    public void ResetLevel()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
