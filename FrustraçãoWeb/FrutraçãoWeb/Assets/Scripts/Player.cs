using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 200f;

    public bool grounded;
    public bool canDoubleJump;

    public int curHealth;
    public int maxHealth;

    public GameObject attackSpawn;
    public GameObject sword;
    public GameObject cam;

    public bool isDead = false;

    public float friction = 0.65f;

    private Rigidbody2D rb2d;
    private Animator anim;

    private bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        //Assure Health don't go beyond MAX
        curHealth = curHealth >= maxHealth ? maxHealth : curHealth;

        //Check if Dead
        if (curHealth <= 0)
            StartCoroutine(Die());

        if (!isDead)
        {
            if (Input.GetAxis("Horizontal") < -0.1f)
            {
                facingRight = false;
                transform.localScale = new Vector3(-2, 2, 1);
            }

            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                facingRight = true;
                transform.localScale = new Vector3(2, 2, 1);
            }

            if (Input.GetButtonDown("Vertical"))
            {
                if (grounded)
                {
                    rb2d.AddForce(Vector2.up * jumpPower);
                    //canDoubleJump = true;
                }
                else
                {
                    if (canDoubleJump)
                    {
                        canDoubleJump = false;
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                        rb2d.AddForce(Vector2.up * jumpPower / 1.75f);
                    }
                }
            }

            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("playerAttack");
            }
        }
    }

    void FixedUpdate()
    {

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.x *= friction;
        easeVelocity.z = 0;

        //Fake Friction
        if (grounded)
            rb2d.velocity = easeVelocity;

        if (!isDead)
        {
            float h = Input.GetAxis("Horizontal");

            //Moving the Player
            rb2d.AddForce(Vector2.right * speed * h);

            //Limiting Speed;
            if (rb2d.velocity.x > maxSpeed)
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

            if (rb2d.velocity.x < -maxSpeed)
                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    IEnumerator Die()
    {
        anim.SetTrigger("playerDead");

        isDead = true;

        yield return new WaitForSeconds(1f);

        cam.GetComponent<GameOver>().GameOverStart();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("Acertou!");

            //CauseDamage(0);
        }
    }

    public void CauseDamage(int dmg)
    {
        curHealth -= dmg;
        if (dmg > 0)
        {
            gameObject.GetComponent<Animation>().Play("FlashRed");
            anim.SetTrigger("playerHurt");
        }
    }

    public IEnumerator KnockBack(float dir, float knockDur, float knockBackPwr, Vector3 knockBackDir)
    {
        float timer = 0;

        Debug.Log("KnockDur " + knockDur + "; knockBackPwr " + knockBackPwr + "; knockBackDir.x " + knockBackDir.x + "; knockBackDir.y " + knockBackDir.y);

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockBackDir.x * dir, knockBackDir.y * knockBackPwr, transform.position.z));
        }

        yield return 0;
    }
}