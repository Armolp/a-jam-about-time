using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour, TimeBehaviour
{
    public int startingHeight = 1;
    public GameObject template;

    int maxHeight = 10;
    SpriteRenderer spriteRenderer;
    List<GameObject> vineObjects;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        vineObjects = new List<GameObject>();
        for(int i = 1; i< startingHeight; i++)
        {
            vineObjects.Add(Instantiate(template,
                transform.position + new Vector3(0, i),
                Quaternion.identity,
                transform));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AgeForwards()
    {
        if (vineObjects.Count < maxHeight-1)
        {
            vineObjects.Add(Instantiate(
                template,
                transform.position + new Vector3(0, vineObjects.Count + 1),
                Quaternion.identity,
                transform));
        }
    }

    public void AgeBackwards()
    {
        if (vineObjects.Count > 1)
        {
            GameObject vine = vineObjects[vineObjects.Count - 1];
            vineObjects.RemoveAt(vineObjects.Count - 1);
            Destroy(vine);
        }
    }
}
