using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public int curHealth;
    public int maxHealth;

    public bool isDead;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        curHealth = maxHealth;
        isDead = false;
    }

    void Update()
    {
        if (curHealth <= 0)
            anim.SetTrigger("playerDead");

        if (isDead)
            Die() ;
    }

    public void Die()
    {
        //Animation dying
        GameObject.Destroy(gameObject);
    }

    public void CauseDamage(int damage)
    {
        curHealth -= damage;

        anim.SetTrigger("playerHurt");
    }
}
