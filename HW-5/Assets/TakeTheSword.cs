using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTheSword : MonoBehaviour
{
    GameObject Player;
    public GameManager gameManager;

    private void Start()
    {
        Player = gameObject.transform.gameObject;//get the player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Sword"))
            collision.gameObject.GetComponent<Renderer>().enabled = false;//get the sword
    }
}
