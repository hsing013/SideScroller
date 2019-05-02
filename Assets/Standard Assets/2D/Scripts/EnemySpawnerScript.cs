using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    bool spawned = false;
    public int amountToSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void spawnEnemy()
    {
        if (!spawned)
        {
            for (int i = 0; i < amountToSpawn; ++i)
            {
                Instantiate(enemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello world");
        spawnEnemy();
    }
}
