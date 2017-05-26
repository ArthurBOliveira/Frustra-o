using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour
{

    public float speed;
    public float maxSpeed;

    public float moveMinX;
    public float moveMaxX;

    public float distance;
    public float followRange;

    public bool awake = false;
    public bool lookingRight = true;

    public Transform target;

    private Animator anim;
    private Rigidbody2D rb2d;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.x *= 0.85f;
        easeVelocity.z = 0;

        //Fake Friction
        rb2d.velocity = easeVelocity;

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        //Moving the Player
        rb2d.AddForce(Vector2.left * speed);

        //Limiting Speed;
        if (rb2d.velocity.x > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x < -maxSpeed)
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

        //Change Direction
        if (rb2d.position.x < moveMinX)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            speed = -100;
        }

        if (rb2d.position.x > moveMaxX)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            speed = 100;
        }
    }

    public void Attack()
    {
        //anim.SetTrigger("Attack");
    }

}
