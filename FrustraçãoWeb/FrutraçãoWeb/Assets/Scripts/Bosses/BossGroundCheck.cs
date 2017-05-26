using UnityEngine;
using System.Collections;

public class BossGroundCheck : MonoBehaviour
{
    private Shadow shadow;

    void Start()
    {
        shadow = gameObject.GetComponentInParent<Shadow>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Invisible")
        {
            shadow.grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag != "Invisible")
        {
            shadow.grounded = false;
        }
    }
}