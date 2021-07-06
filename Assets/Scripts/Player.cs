using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask obstacleLayer;

    private Vector3 nextPosition;

    TimeBehaviour[] timeAffected;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = transform.position;
        timeAffected = FindObjectsOfType<MonoBehaviour>().OfType<TimeBehaviour>().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * UnityEngine.Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPosition) == 0)
        {
            if( Input.GetAxis("Horizontal") > 0 && PositionIsAvilable(nextPosition + new Vector3(1,0)))
            {
                nextPosition.x++;

                // move time forwards
                foreach(TimeBehaviour timeObj in timeAffected)
                {
                    timeObj.AgeForwards();
                }
            }
            else if (Input.GetAxis("Horizontal") < 0 && PositionIsAvilable(nextPosition + new Vector3(-1, 0)))
            {
                nextPosition.x--;

                // move time backwards
                foreach (TimeBehaviour timeObj in timeAffected)
                {
                    timeObj.AgeBackwards();
                }
            }
            else if (Input.GetAxis("Vertical") > 0 && PositionIsAvilable(nextPosition + new Vector3(0, 1)))
            {
                nextPosition.y++;
            }
            else if (Input.GetAxis("Vertical") < 0 && PositionIsAvilable(nextPosition + new Vector3(0, -1)))
            {
                nextPosition.y--;
            }
        }
    }

    bool PositionIsAvilable(Vector2 position)
    {
        return !Physics2D.OverlapCircle(position, 0.2f, obstacleLayer);
    }

    bool IsFlagReached()
    {
        return false;
    }
}
