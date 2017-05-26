using UnityEngine;
using System.Collections;

public class AttackConePlant : MonoBehaviour
{
    public PlantAI plant;

    void Awake()
    {
        plant = gameObject.GetComponentInParent<PlantAI>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            plant.Attack();
    }
}
