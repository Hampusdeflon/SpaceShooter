using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    //Player Bullet:
    public GameObject playerBullet;
    public Transform bulletSpawnPos;
    public float attackTimer = 1f;
    private float curAttackTimerc;

    //Audio
    public AudioSource bulletSound;

    //Health
    public HealthBar healthBar;
    public int maxHealth = 10;
    private int currentHealth;

    //Animation
    private Animator anim;

    public GameOver gameOverScreen;     //Takes the GameOver.cs file 



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        curAttackTimerc = attackTimer;

    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float directionY = Input.GetAxisRaw("Vertical"); // arrow up = 1, arrow down = -1
        playerDirection = new Vector2(0, directionY).normalized;

        ShootBullet();

        anim.SetBool("movingDown", rb.velocity.y < 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    void ShootBullet()
    {
        attackTimer += Time.deltaTime;
        if(attackTimer > curAttackTimerc)
        {
            if (Input.GetKey(KeyCode.D))
            {
                attackTimer = 0;
                Instantiate(playerBullet, bulletSpawnPos.position, Quaternion.identity);
                bulletSound.PlayDelayed(0);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentHealth == 1)
        {
            int score = (int)FindObjectOfType<ScoreManager>().score;
            gameOverScreen.SetupScreen(score);
        }

        switch (collision.tag)
        {
            case "EnemyBullet":
                healthBar.SetHealth(--currentHealth);
                Destroy(collision.gameObject);
                break;

            case "Enemy":
                healthBar.SetHealth(--currentHealth);
                Destroy(collision.gameObject);
                break;

            case "Life":
                currentHealth = Mathf.Clamp(currentHealth, (currentHealth + 5), maxHealth);
                healthBar.SetHealth(currentHealth);
                Destroy(collision.gameObject);
                break;

            default:
                break;        }
    }
}
