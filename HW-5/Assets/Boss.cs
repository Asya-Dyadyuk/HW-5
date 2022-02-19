using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;// will be used to control the Animator variables 

    GameManager gm;

    public int maxHp = 100;
    int EnemyHp;
    public bool isAlive = true;


    public Transform player;

    public bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHp = maxHp;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }

    private void Update()
    {
        //LookAtPlayer();
    }

    public void takeDamage(int amountOfDamage)
    {
        EnemyHp -= amountOfDamage;

        animator.SetTrigger("hit");

        if (EnemyHp <= 0)
            die();

        gm.CompleteLevel();
    }

    void die()
    {
        this.isAlive = false;
        animator.SetBool("Dead", true);//get to the death animation

        this.enabled = false;//make the enemy disappear
    }
}
