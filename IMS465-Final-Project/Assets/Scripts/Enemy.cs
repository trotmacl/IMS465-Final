using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp;
    public Cell cell;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (cell.isSpotlight)
        {
            hp -= 1.5f;
        }
        else {
            hp -= 1.0f;
        }

        if (hp < 0.1f) {
            Destroy(this);
        }
    }
}
