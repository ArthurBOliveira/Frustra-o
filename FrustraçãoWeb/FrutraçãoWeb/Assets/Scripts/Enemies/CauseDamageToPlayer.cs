using UnityEngine;
using System.Collections;

public class CauseDamageToPlayer : MonoBehaviour {

    public int Damage;
    public bool DestroyOnTouch = true;

    public float knockDur = 0.2f;
    public float knockBackPwr = -3;
    public float dir = 3;

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
            player.CauseDamage(Damage);
            if (DestroyOnTouch)
                GameObject.Destroy(gameObject);

            //StartCoroutine(player.KnockBack(dir, knockDur, knockBackPwr, player.transform.position));
        }
    }
}
