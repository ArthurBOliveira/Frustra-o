using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour
{
    private Player player;
    public string nextLevel;

    private bool playerIn = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") )
        {
            playerIn = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerIn = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && playerIn)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
