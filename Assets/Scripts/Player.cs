using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask obstacleLayer;

    private Vector3 nextPosition;
    StudioEventEmitter emitter;

    TimeBehaviour[] timeAffected;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = transform.position;
        timeAffected = FindObjectsOfType<MonoBehaviour>().OfType<TimeBehaviour>().ToArray();


        var target = GameObject.Find("Music Lvl1 Emitter");
        emitter = target.GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        float Xpos = (transform.position.x + 15 / 2.0f) / 15;
        emitter.SetParameter("Xpos", 1);

        nextPosition.z = transform.position.z;
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
            else if (Input.GetButton("Reset"))
            {
                int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIdx);
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
