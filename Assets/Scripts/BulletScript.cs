using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletScript : MonoBehaviour
{
    public float velocity = 10f;
    private string parentName = "";
    private Animator animator;
    private bool stopped = false;

    // Update is called once per frame
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!stopped)    
            transform.Translate(Vector3.down * Time.deltaTime * velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(parentName == "")
        {
            parentName = collision.gameObject.name;
            return;
        }
        if (parentName == collision.gameObject.name)
            return;

        if (collision.gameObject.layer == 3) //Walls
        {
            animator.SetTrigger("hasColided");
            stopped = true;
            Destroy(gameObject, 0.16f);
        }
        else if(collision.gameObject.name.Contains("Limit"))
            Destroy(gameObject, 0.1f);
        else
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
