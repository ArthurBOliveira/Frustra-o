using UnityEngine;
using System.Collections;

public class AttackConeZombie : MonoBehaviour
{

    ZombieAI zombieAI;

    // Use this for initialization
    void Start()
    {
        zombieAI = GetComponentInParent<ZombieAI>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            zombieAI.Attack();
        }
    }
}
