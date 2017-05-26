using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject EndingUI;

    public string nextScene;

    private bool paused = false;

    // Use this for initialization
    void Start()
    {
        EndingUI.SetActive(false);
    }

    void Update()
    {
        if (paused)
        {
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
    }

    public void EndingStart()
    {
        EndingUI.SetActive(true);
        paused = true;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
