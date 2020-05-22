﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = null;
    [SerializeField] float moveSpeed = 2f;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPostion = waypoints[waypointIndex].transform.position;
            var movementPerFrame = moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPostion, movementPerFrame);

            if (transform.position == targetPostion)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
