using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletdirection;
    public float bulletSpeed;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }
    void MoveBullet()
    {
        Vector3 tempPosition = transform.position;
        tempPosition.x += bulletSpeed * Time.deltaTime  * bulletdirection;
        transform.position = tempPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
