using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        Debug.Log("Taking damage");
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
