using UnityEngine;
using System.Collections;

public class SpawnIceSkull : MonoBehaviour
{
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public GameObject SpawnTop;
    public GameObject SpawnBottom;

    public GameObject iceSkull;

    public void Update()
    {
            bulletTimer += Time.deltaTime;

            if (bulletTimer >= shootInterval)
            {
                Vector2 directionTop = SpawnTop.transform.position;
                Vector2 directionBottom = SpawnBottom.transform.position;

                GameObject bulletClone;
                bulletClone = Instantiate(iceSkull, SpawnTop.transform.position, SpawnTop.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);

                GameObject bulletClone1;
                bulletClone1 = Instantiate(iceSkull, SpawnBottom.transform.position, SpawnBottom.transform.rotation) as GameObject;
                bulletClone1.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);

                bulletTimer = 0;
            }
    }
}
