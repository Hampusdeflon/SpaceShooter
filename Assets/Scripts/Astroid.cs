using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public string astroidType;

    public HealthBar healthBar;
    public int maxHealth;
    private int currentHealth;

    public GameObject itemToDrop;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Instantiate(itemToDrop, transform.position, transform.rotation);

            }
        }
        if (collision.gameObject.name == "Left Border") 
        {
            Destroy(this.gameObject);
        }
    }

}
