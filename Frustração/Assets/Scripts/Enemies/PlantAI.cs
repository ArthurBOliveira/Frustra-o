using UnityEngine;
using System.Collections;

public class PlantAI : MonoBehaviour
{
    public float distance;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPoint;
    private Player player;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        RangeCheck();
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
    }

    public void Attack()
    {
        if (!player.isDead)
        {
            anim.SetTrigger("Attack");

            bulletTimer += Time.deltaTime;

            if (bulletTimer >= shootInterval)
            {
                Vector2 direction = target.transform.position;

                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }
        }
    }
}
