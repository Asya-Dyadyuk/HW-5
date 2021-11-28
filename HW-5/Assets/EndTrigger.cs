using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    
    public Transform player;
    public GameManager gameManager;
    TextMesh gameOver;
    bool flag = true;
    // Update is called once per frame
    void Update()
    {
        if (player.position.y <= -10 && flag)
        { 
            flag = false;
            gameManager.EndGame();
        }
    
    }  
}
