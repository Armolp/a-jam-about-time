using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flag : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < 0.1f)
        {
            int currentIdx = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIdx+1);
        }
    }
}
