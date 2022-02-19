using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;// will be used to control the Animator variables 

    public Transform attackPoint;//the position of the sword
    public float atatckRange = 0.5f;
    public LayerMask enemyLayers;//who are the enemys?

    public int attackDamage = 50;

    //rate of attack
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                attack();
                this.nextAttackTime = Time.time + 1f / attackRate;
            }
    }

    private void attack()
    {
        animator.SetTrigger("BanditAttacks");

        //detecting the enemeys
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, atatckRange, enemyLayers);

        //demege the enemys
        foreach(Collider2D enemy in hit)
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        //show me the range of the attack
        Gizmos.DrawWireSphere(attackPoint.position, atatckRange);
    }

}
