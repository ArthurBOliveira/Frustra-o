using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public int curHealth;
    public int maxHealth;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (curHealth <= 0)
            Die();
    }

    void Die()
    {
        //Animation dying
        GameObject.Destroy(gameObject);
    }

    public void CauseDamage(int damage)
    {
        curHealth -= damage;
    }
}
