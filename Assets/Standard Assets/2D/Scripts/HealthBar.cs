using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementBar(float f)
    {
        Vector3 vector = new Vector3(f + bar.localScale.x, 1f);
        if (vector.x > 1f)
        {
            vector.x = 1f;
        }
        bar.localScale = vector;
    }
    public void decrementBar(float f)
    {
        Vector3 vector = new Vector3(bar.localScale.x - f, 1f);
        if (vector.x < 0f)
        {
            vector.x = 0f;
        }
        bar.localScale = vector;
    }
}
