using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public double Xpos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform tr = player.GetComponent<Transform>();
        // tr.x
        Xpos = (tr.position.x + 15 / 2.0) / 15;
    }
}
