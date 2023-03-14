using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [System.NonSerialized]
    public int maxHealth = 10;
    public int health = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public  void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
