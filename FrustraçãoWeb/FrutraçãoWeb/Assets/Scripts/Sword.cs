using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    public int damage;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().CauseDamage(damage);
            }

            if (col.CompareTag("Boss"))
            {
                col.GetComponent<Boss>().CauseDamage(damage);
            }
        }
    }

    void Update()
    {
        //transform.position = new Vector3(0.3604f, 0.1029f, 0f);
    }
}