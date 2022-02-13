using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float HP = 100f;
    public Image bar;
    public GameManager gameManager;
    GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP -= 15;
            bar.fillAmount = HP / 100;
        }
        if (HP == 0)
             //Player.GetComponent<Collider2D>().enabled = false;
            // Player.GetComponent<SpriteRenderer>().flipY = true;


            // move him;
            //Vector2 movement = new Vector2(Random.Range(40, 70), Random.Range(-40, 40));
            // Player.transform.position = (Vector2)Player.transform.position + (movement * Time.deltaTime);
             //Player.GetComponent<Renderer>().enabled = false;//remove the player
             gameManager.EndGame();
    }
}
