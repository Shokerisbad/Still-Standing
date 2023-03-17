using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float velocity = 1f;
    private float x, y, angle;
    private Vector3 mousePosition;
    private Animator animator;

    void Update() 
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
        angle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 180, -Vector3.forward); 
    }

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x * velocity * Time.deltaTime, y * velocity * Time.deltaTime, 0);
    }
}