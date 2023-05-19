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

    // Update is called once per frame
    void Update()
    {
        if (Aipath.desiredVelocity != Vector3.zero)
        {
            transform.up = Aipath.desiredVelocity;
            return;
        }

        playerPosition = transform.position - aIDestinationSetter.target.position;
        angle = Mathf.Atan2(playerPosition.x, playerPosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(-angle + 180, Vector3.forward), rotationVelocity * Time.deltaTime);
    }
}

