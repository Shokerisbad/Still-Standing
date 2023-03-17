using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{ 
    private Vector3 mousePosition;
    private float timePassed = 0;
    public Rigidbody2D bullet;
    public float FireRate = 1f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.ResetTrigger("isShooting");
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10)) - transform.position;

        if (Input.GetMouseButton(0) && Time.time - timePassed >= FireRate)
        {
            animator.SetTrigger("isShooting");
            timePassed = Time.time;
            Rigidbody2D projectile = Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
