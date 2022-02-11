using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public string astroidType;
    private Rigidbody2D rb;


    //Health
    public HealthBar healthBar;
    public int maxHealth;
    private int currentHealth;

    public GameObject itemToDrop;


    


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        //Health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


    }

    private void Update()
    {
        
        rb.position = new Vector2(rb.position.x -0.010f, (rb.position.y) -0.003f);
        rb.transform.Rotate(0, 0, 17 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            healthBar.SetHealth(--currentHealth);
            if (currentHealth == 0 )
            {
                Destroy(this.gameObject);
                Instantiate(itemToDrop, transform.position, Quaternion.identity); //Quaternion.identity = (0,0,0)  -> no rotation
            }
        }
        if (collision.gameObject.name == "Left Border") 
        {
            Destroy(this.gameObject);
        }
    }

}
