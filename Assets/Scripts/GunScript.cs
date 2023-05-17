using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunScript : MonoBehaviour
{ 
    private Vector3 mousePosition, startPos;
    private float timePassed = 0, timeClickStart = 0, reloadStart = 0;
    public Rigidbody2D bullet;
    public float bulletSwayAngle = 0f;
    public float fireRate = 1f;
    public int maxAmmo = 9;
    public int reloadSpeed = 2;
    public int ammo;
    private Animator animator;
    private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            animator = GetComponent<Animator>();
        }
        catch (Exception e)
        {
            animator = null;
        }
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null) 
            animator.ResetTrigger("isShooting");

        if (transform.name.Equals("Player"))
            handlePlayerGun();
        else if (transform.tag.Equals("Enemy"))
            shoot();
    }

    void handlePlayerGun() {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10)) - transform.position;

        if (reloading && Time.time - reloadStart >= reloadSpeed)
        {
            reloading = false;
            ammo = maxAmmo;
        }

        if (!reloading)
        {
            if (Input.GetMouseButton(0) && timeClickStart == 0)
            {
                timeClickStart = Time.time;
            }
            if (Input.GetMouseButton(0) && Time.time - timePassed >= fireRate && Time.time - timeClickStart >= 0.1)
            {
                ammo--;
                animator.SetTrigger("isShooting");
                timePassed = Time.time;
                Rigidbody2D projectile = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, UnityEngine.Random.Range(-bulletSwayAngle, bulletSwayAngle)));
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - timeClickStart >= 0.06)
                {
                    ammo--;
                    animator.SetTrigger("isShooting");
                    timePassed = Time.time;
                    Rigidbody2D projectile = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, UnityEngine.Random.Range(-bulletSwayAngle, bulletSwayAngle)));
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

    void shoot() {
        startPos = transform.position - (transform.up * 0.25f);

        Boolean sawPlayer = false;
        for (int i = -10; i < 10; i++)
        {
            //Debug.DrawRay(startPos, -(Quaternion.Euler(0, 0, i) * transform.up) * 10);
            RaycastHit2D hit = Physics2D.Raycast(startPos, -(Quaternion.Euler(0, 0, i) * transform.up), 10, LayerMask.GetMask("Player"));
            if (hit.collider != null && hit.collider.transform.tag.Equals("Player")) { 
                sawPlayer = true;
                break;
            }
        }
        if (!sawPlayer)
            return;

        if (reloading && Time.time - reloadStart >= reloadSpeed)
        {
            reloading = false;
            ammo = maxAmmo;
        }

        if (!reloading && Time.time - timePassed >= fireRate)
        {
            ammo--;
            //animator.SetTrigger("isShooting");
            timePassed = Time.time;
            Rigidbody2D projectile = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, UnityEngine.Random.Range(-bulletSwayAngle, bulletSwayAngle)));
        }

        if (!reloading && ammo == 0)
        {
            reloading = true;
            reloadStart = Time.time;
        }
    }
}
