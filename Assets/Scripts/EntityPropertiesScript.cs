using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPropertiesScript : MonoBehaviour
{
    public int damage = 0;
    public int maxHealth = 10;
    public int health = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           collision.gameObject.GetComponent<EntityPropertiesScript>().TakeDamage(damage);
        }
    }

}
