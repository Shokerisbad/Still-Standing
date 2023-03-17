using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsScript : MonoBehaviour
{
    private Vector3 mousePosition;
    public GameObject player;
    private Animator animator;
    private float x, y, angle;
    public float dampener = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("velocity", player.GetComponent<MovementScript>().velocity * dampener);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.Translate(Vector3.down * 0f);
        transform.Translate(Vector3.right * 0f);

        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
        angle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;

        if (x > 0 && y > 0)
            angle = 45;
        else if (x > 0 && y < 0)
            angle = 125;
        else if (x < 0 && y < 0)
            angle = 225;
        else if ((x < 0 && y > 0))
            angle = 295;
        else if (x > 0)
            angle = 90;
        else if (x < 0)
            angle = 270;
        else if (y > 0)
            angle = 0;
        else if (y < 0)
            angle = 180;
        else
        {
            if (angle >= -45 && angle <= 45)
                angle = 180;
            else if (angle >= 45 && angle <= 135)
                angle = 270;
            else if (angle >= -135 && angle <= -45)
                angle = 90;
            else if ((angle > 135 && angle < 180) || (angle > -180 && angle < -135))
                angle = 0;
            else
                angle = 0;
        }

        transform.rotation = Quaternion.AngleAxis(angle + 180, -Vector3.forward);
    }

    void FixedUpdate()
    {
        animator.ResetTrigger("isMoving");
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        

        if (x != 0 || y != 0)
            animator.SetTrigger("isMoving");
    }
}
