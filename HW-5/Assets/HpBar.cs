using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float hp = 100f;
    public Image bar;
    public GameManager gameManager;
    public GameObject Player;
    public Animator animator;// will be used to control the Animator variables 

    // Update is called once per frame
    void Update()
    {
        if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("Bandit_demage"))
            animator.SetBool("EnemyAttacks", false);


        //we are dead
        if ( hp == 0)
        {
            //it the animation is over then change this value
            animator.SetBool("EnemyAttacks", false);
            die();

            gameManager.EndGame();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //queue the attack
            animator.SetBool("EnemyAttacks", true);

            hp -= 15;//take damage
            if (hp < 0)
            {
                hp = 0;//15 das not sum up to 100
                animator.SetFloat("hp", 0);
                animator.SetBool("BanditIsDead", true);
            }
            bar.fillAmount = hp / 100;
        }
    }

    public void takeDamage(int amountOfDamage)
    {
        hp -= amountOfDamage;

        animator.SetTrigger("Bandit_demage");

        if (hp <= 0)
            hp = 0;
        bar.fillAmount = hp / 100;

    }

    public void takePotion()
    {
        if (this.hp + 25 > 100)
            this.hp = 100;
        else
            this.hp += 25;
        bar.fillAmount = hp / 100;
        animator.SetFloat("hp", this.hp);
    }

    public void die()
    {
        this.hp = 0;//15 das not sum up to 100
        animator.SetFloat("hp", this.hp);
        animator.SetBool("BanditIsDead", true);
        Player.GetComponent<PlayerMovment>().runSpeed = 0f;//paralyze
    }
}
