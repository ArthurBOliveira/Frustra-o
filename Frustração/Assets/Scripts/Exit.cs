using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
    private Player player;

    public GameObject cam;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            cam.GetComponent<Ending>().EndingStart();
        }
    }
}
