using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int damage;

    public float knockDur;
    public float knockBackPwr;
    public float dir;

    private Player player;

    public float interval = 3.0f;
    private float timestamp = .0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        timestamp = Time.time;  // save the timestamp when the bullet instantiated
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            if (col.CompareTag("Player"))
            {
                player.CauseDamage(damage);

                StartCoroutine(player.KnockBack(dir, knockDur, knockBackPwr, player.transform.position));

                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (interval < Time.time - timestamp)
        {
            Destroy(gameObject);  // destroy the bullet after {interval} seconds
        }
    }
}
