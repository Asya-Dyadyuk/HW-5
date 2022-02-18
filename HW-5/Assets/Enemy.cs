using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;// will be used to control the Animator variables 

    public int maxHp = 100;
    int EnemyHp;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHp = maxHp;
    }

    public void takeDamage(int amountOfDamage)
    {
        EnemyHp -= amountOfDamage;

        animator.SetTrigger("hit");

        if (EnemyHp <= 0)
            die();

    }

    void die()
    {
        animator.SetBool("Dead", true);//get to the deth animation

        //get the Collider and cancel it.
        GetComponent<Collider2D>().enabled = false;


        this.enabled = false;//make the enemy disapper
    }
}
