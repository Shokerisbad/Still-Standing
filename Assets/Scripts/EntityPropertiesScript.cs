using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPropertiesScript : MonoBehaviour
{
    public int damage = 0;
    public int maxHealth = 10;
    public int health = 0;
    //public bool alive;
    

    // Start is called before the first frame update
    void Start()
    {
       
        health = maxHealth;
        //alive = true;
    }

    public int GetHp()
    {
        return health;
    }
    

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //alive = false;
            health = 0;
            Destroy(gameObject, 0.1f);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           collision.gameObject.GetComponent<EntityPropertiesScript>().TakeDamage(damage);
        }
    }

   /* public bool Alive()
    {
        return alive;
    }

      public void CheckIfAlive()
    {
        if (health > 0)
        {
            alive = true;
        }
        else if (health <= 0)
        {
            // imager.rectTransform.sizeDelta = new Vector2(400, imager.rectTransform.sizeDelta.y);
            alive = false;
        }
    }
   */
}
