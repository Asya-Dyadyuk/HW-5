using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeThePotion : MonoBehaviour
{
    GameObject player;
    public GameManager gameManager;
    public Animator animator;// will be used to control the Animator variables 

    private void Start()
    {
        player = gameObject.transform.gameObject;//get the player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("HealthPotion"))
        {
            collision.gameObject.GetComponent<Renderer>().enabled = false;//get the Potion

            player.GetComponent<HpBar>().takePotion();
        }

        if (collision.gameObject.tag.Equals("JumpPotion"))
        {
            collision.gameObject.GetComponent<Renderer>().enabled = false;//get the Potion

            player.GetComponent<CharacterController>().setJumpForce();
        }


    }
}
