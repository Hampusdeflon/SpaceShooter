using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Bullet
    public GameObject enemyBullet;
    public Transform bulletSpawnPos;
    public float shootTimer = 1;
    private float curShootTimer;
    public int followPlayerSpeed;

    public AudioSource bulletSound;

    //Animation
    private Animator anim;


    //Chase Player
    private Rigidbody2D rb;
    private Transform player;
    public float moveSpeed = 10;
    private Vector2 movement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        curShootTimer = shootTimer;
        shootTimer = Random.Range(shootTimer/5, shootTimer); //make it possible for the first bullet to spawn faster than shootingdelay
        rb = this.GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ShootBullet();
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();
        movement = directionToPlayer;

        moveSpeed -= moveSpeed * (Time.deltaTime / followPlayerSpeed);
    }
    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 dirToPlayer)
    {
        rb.MovePosition((Vector2)transform.position + (dirToPlayer * moveSpeed * Time.deltaTime) );
    }

    void ShootBullet()
    {
        if(shootTimer > curShootTimer)
        {
            shootTimer = 0;
            Instantiate(enemyBullet, bulletSpawnPos.position, Quaternion.identity);
            bulletSound.PlayDelayed(0);

        }
        shootTimer += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Left Border" )
        {
            Destroy(this.gameObject);
        }
        if(collision.tag == "PlayerBullet")
        {
            anim.SetTrigger("enemyDeathExplosion");

            Destroy(this.gameObject, 0.11f);          //destroy after (0.11 sec = anim duration)
            Destroy(collision.gameObject);    
            FindObjectOfType<ScoreManager>().score++;
        }
    }
}
