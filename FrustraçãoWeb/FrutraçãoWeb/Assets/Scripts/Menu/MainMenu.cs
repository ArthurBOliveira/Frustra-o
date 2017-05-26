using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ChangeLanguage()
    {
        //TODO
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Nexus");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
