using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovementScript : MonoBehaviour
{
    public AIPath Aipath;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyVelocity();
    }

    void enemyVelocity()
    {
        direction = Aipath.desiredVelocity;
        transform.up = direction;
    }

}

