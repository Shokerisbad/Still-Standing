using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsScript : MonoBehaviour
{
    private Vector3 mousePosition;
    public GameObject player;
    private Animator animator = null;
    private float x, y, angle;
    public float dampener = 0.5f;
    private Quaternion rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (player.tag.Equals("Player"))
            animator.SetFloat("velocity", player.GetComponent<MovementScript>().velocity * dampener);
        else if (player.tag.Equals("Enemy"))
            animator.SetFloat("velocity", player.GetComponent<AIPath>().maxSpeed * dampener);
    }

    // Update is called once per frame
    void Update()
    {   
        angle = player.transform.eulerAngles.z;

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
            if (angle >= 0 && angle <= 45)
                angle = 0;
            else if (angle >= 45 && angle <= 135)
                angle = 270;
            else if (angle >= 135 && angle <= 225)
                angle = 180;
            else if (angle > 225 && angle <= 315)
                angle = 90;
            else
                angle = 0;
        }

        rotation = Quaternion.RotateTowards(rotation, Quaternion.AngleAxis(angle + 180, -Vector3.forward), 720 * Time.deltaTime);
        transform.rotation = rotation;
    }

    void FixedUpdate()
    {
        #pragma warning disable CS0436 // Type conflicts with imported type

        animator.ResetTrigger("isMoving");

        if (player.tag.Equals("Player"))
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            if (x != 0 || y != 0)
                animator.SetTrigger("isMoving");
        }
        else if (player.tag.Equals("Enemy") && player.GetComponent<EnemyMovementScript>().getVelocity() != 0)
            animator.SetTrigger("isMoving");
        
        #pragma warning restore CS0436 // Type conflicts with imported type
    }
}
