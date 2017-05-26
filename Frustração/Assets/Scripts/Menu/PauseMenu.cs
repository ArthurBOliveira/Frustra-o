using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Player player;
    public GameObject PauseUI;

    private bool paused = false;

    // Use this for initialization
    void Start()
    {
        PauseUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            if (Input.GetButtonDown("Pause"))
                paused = !paused;

            if (paused)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0;
            }

            if (!paused)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        paused = false;
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