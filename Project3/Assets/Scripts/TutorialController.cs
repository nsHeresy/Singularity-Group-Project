using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
