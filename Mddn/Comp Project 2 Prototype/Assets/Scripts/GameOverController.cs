using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public Canvas UI;
    
    /// <summary>
    /// Quits to the main menu, associated with button press.
    /// </summary>
    public void QuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
