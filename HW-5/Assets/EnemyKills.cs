using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKills : MonoBehaviour
{
    GameObject Player;
    public GameManager gameManager;

    private void Start()
    {
        Player = gameObject.transform.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Player.GetComponent<Collider2D>().enabled = false;
            Player.GetComponent<SpriteRenderer>().flipY = true;
            //Destroy(collision.gameObject);//Destroy the Enemy

            // move him;
            Vector2 movement = new Vector2(Random.Range(40, 70), Random.Range(-40, 40));
            Player.transform.position = (Vector2)Player.transform.position + (movement * Time.deltaTime);
            //Destroy(Player);//Destroy the Player
            Player.GetComponent<Renderer>().enabled = false;//remove the player
            gameManager.EndGame();
        }
    }
}
