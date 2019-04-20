using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(enemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        
    }
}
