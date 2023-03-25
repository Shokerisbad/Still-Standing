using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{ 
    private Vector3 mousePosition;
    private float timePassed = 0, timeClickStart = 0, reloadStart = 0;
    public Rigidbody2D bullet;
    public float FireRate = 1f;
    public int maxAmmo = 9;
    public int reloadSpeed = 2;
    public int ammo;
    private Animator animator;
    private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        animator.ResetTrigger("isShooting");
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10)) - transform.position;

        if(reloading && Time.time - reloadStart >= reloadSpeed)
        {
            reloadStart = 0;
            reloading = false;
            ammo = maxAmmo;
        }

        if (!reloading)
        {
            if (Input.GetMouseButton(0) && timeClickStart == 0)
            {
                timeClickStart = Time.time;
            }
            if (Input.GetMouseButton(0) && Time.time - timePassed >= FireRate && Time.time - timeClickStart >= 0.1)
            {
                ammo--;
                animator.SetTrigger("isShooting");
                timePassed = Time.time;
                Rigidbody2D projectile = Instantiate(bullet, transform.position, transform.rotation);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - timeClickStart >= 0.06)
                {
                    ammo--;
                    animator.SetTrigger("isShooting");
                    timePassed = Time.time;
                    Rigidbody2D projectile = Instantiate(bullet, transform.position, transform.rotation);
                }
                timeClickStart = 0;
            }

            if (ammo == 0)
            {
                reloading = true;
                reloadStart = Time.time;
            }
        }
    }
}
