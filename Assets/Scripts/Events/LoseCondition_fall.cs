using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition_fall : MonoBehaviour
{
    Transform player;
    public GameOver gameOver;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.y < -5)
        {
            gameOver.EndTheGame();
        }
    }
}
