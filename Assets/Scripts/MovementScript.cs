using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float velocity = 1f;
    public int rotationVelocity = 360;
    private float x, y, angle;
    private Vector3 mousePosition, input;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update() 
    {
        mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
        angle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle + 180, -Vector3.forward), rotationVelocity * Time.deltaTime); 
    }

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        input = new Vector3(x, y, 0);
        input.Normalize();

        transform.position += input * (velocity * Time.deltaTime);
    }
}