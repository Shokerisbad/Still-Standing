using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPropertiesScript : MonoBehaviour
{
    public int contactDamage = 2;
    public int maxHealth = 100;
    public int health = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public int GetHp()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           collision.gameObject.GetComponent<EntityPropertiesScript>().TakeDamage(contactDamage);
        }
    }

    private void OnDestroy()
    {
        if (transform.tag.Equals("Enemy") && transform.parent != null)
            transform.parent.transform.GetComponent<WaveManagerScript>().EnemyKilled();
    }
}
