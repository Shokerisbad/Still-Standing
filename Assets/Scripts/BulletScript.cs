using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletScript : MonoBehaviour
{
    private int damage = 1;
    public float velocity = 10f;
    private string parentTag = "";
    private Animator animator;
    private bool stopped = false;

    // Update is called once per frame
    void Start()
    {  
        animator = GetComponent<Animator>();
        transform.Translate(Vector3.down * 0.5f);
        transform.Translate(Vector3.left * 0.1f);
    }

    void Update()
    {
        if(!stopped)    
            transform.Translate(Vector3.down * Time.deltaTime * velocity);
    }

    public void setPropreties(int damage, String parentTag)
    {
        this.parentTag = parentTag;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(parentName == "")
            parentName = collision.gameObject.name;
        else if (parentName == collision.gameObject.name)
            return;*/

        if (collision.gameObject.layer == 3) //Walls
        {
            animator.SetTrigger("hasColided");
            stopped = true;
            Destroy(gameObject, 0.16f);
        }
        else if(collision.gameObject.name.Contains("Limit"))
            Destroy(gameObject, 0.1f);
        else if (collision.transform.tag.Equals("Enemy") && parentTag.Equals("Player")
              || collision.transform.tag.Equals("Player") && parentTag.Equals("Enemy")) //enemy <-> player
        {
            animator.SetTrigger("hasColided");
            stopped = true;
            collision.gameObject.GetComponent<EntityPropertiesScript>().TakeDamage(damage);
            Destroy(gameObject, 0.16f);
            
        }
    }
}
