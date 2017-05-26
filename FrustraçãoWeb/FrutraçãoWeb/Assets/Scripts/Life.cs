using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

    public int hp;
    public GameObject spriteObject;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damager")
        {
            //other.GetComponent<Player>().CauseDamage(damageByImpact);
            CauseDamage(1);            
        }
    }

    void CauseDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            //Destroy Object
        }
    }
}
