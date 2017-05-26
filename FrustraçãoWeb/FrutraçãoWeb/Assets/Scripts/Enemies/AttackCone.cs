using UnityEngine;
using System.Collections;

public class AttackCone : MonoBehaviour
{
    public Turret turret;

    public bool isRight = false;

    void Awake()
    {
        turret = gameObject.GetComponentInParent<Turret>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            turret.Attack(isRight);
    }
}
