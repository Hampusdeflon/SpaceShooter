using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    public GameObject astroidSmall;
    public GameObject astroidBig;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    private float astroidSpawnTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        //Enemies
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(enemy, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

        //Astroids
        astroidSpawnTimer++;
        if(astroidSpawnTimer % 8 == 0)
        {
            Instantiate(astroidSmall, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        if (astroidSpawnTimer % 21 == 0)
        {
            Instantiate(astroidBig, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

        }
    }
}
