using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, TimeBehaviour
{
    public List<Sprite> sprites;
    public int currentState = 0;
    public int whenIsObstacle = 4;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (sprites.Count > currentState)
        {
            spriteRenderer.sprite = sprites[currentState];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState < 0)
            currentState = 0;
        if (currentState > sprites.Count - 1)
            currentState = sprites.Count - 1;

        if (currentState < whenIsObstacle)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        } else
        {
            gameObject.layer = LayerMask.NameToLayer("Obstacle");
        }

        spriteRenderer.sprite = sprites[currentState];
    }

    public void AgeForwards()
    {
        currentState++;
    }

    public void AgeBackwards()
    {
        currentState--;
    }
}
