using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
    public int damage;

    public float knockDur;
    public float knockBackPwr;
    public float dir;

    private Player player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.CauseDamage(damage);

            StartCoroutine(player.KnockBack(dir, knockDur, knockBackPwr, player.transform.position));
        }
    }
}
