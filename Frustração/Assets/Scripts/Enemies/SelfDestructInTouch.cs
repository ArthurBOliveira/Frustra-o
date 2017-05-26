using UnityEngine;
using System.Collections;

public class SelfDestructInTouch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject.Destroy(transform.parent.gameObject);
    }
}
