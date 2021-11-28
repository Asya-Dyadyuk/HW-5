using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWinTrigger : MonoBehaviour
{
    public Transform player;
    public GameManager gameManager;
    TextMesh gameOver;

    // Update is called once per frame

    void Update()
    {
        if (player.position.x >= 82.511)
        {
            gameManager.CompleteLevel();
        }

    }
}
