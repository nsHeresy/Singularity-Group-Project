using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    
    public void NewGame() {
        SceneManager.LoadScene("GameLevel");
    }

    public void About() {
        Debug.Log("About Button - Unimplemented");
    }

    public void Credits() {
        Debug.Log("Credits Button - Unimplemented");
    }

    public void Quit() {
        Application.Quit();
    }
}
