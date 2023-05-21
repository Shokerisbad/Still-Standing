using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovementScript : MonoBehaviour
{
    public AIPath Aipath;
    public AIDestinationSetter aIDestinationSetter;
    public int rotationVelocity = 360;
    private Vector3 playerPosition;
    private float angle;
    public float velocity = 0f;

    // Update is called once per frame
    void Update()
    {
        if (aIDestinationSetter.target == null)
            return;

        if (Aipath.desiredVelocity != Vector3.zero)
        {
            transform.up = Aipath.desiredVelocity;
            velocity = Aipath.maxSpeed;
            return;
        }

        velocity = 0;
        playerPosition = transform.position - aIDestinationSetter.target.position;
        angle = Mathf.Atan2(playerPosition.x, playerPosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(-angle + 180, Vector3.forward), rotationVelocity * Time.deltaTime);
    }

    public float getVelocity()
    {
        return velocity;
    }
}

