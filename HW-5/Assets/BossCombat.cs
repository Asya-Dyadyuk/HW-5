using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public Animator animator;// will be used to control the Animator variables 

    public Transform attackPoint;//the position of the sword
    public float atatckRange = 10f;
    public LayerMask enemyLayers;//who are the enemies?

    public int attackDamage = 25;

    //rate of attack
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                attack();
                this.nextAttackTime = Time.time + 1f / attackRate;
            }
    }

    public void attack()
    {
        //animator.SetTrigger("Skeleton_Attacks");

        //detecting the enemeyeaios
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, atatckRange, enemyLayers);

        //damage the bandit
        if (hit != null)
            hit.GetComponent<HpBar>().takeDamage(attackDamage);

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        //show me the range of the attack
        Gizmos.DrawWireSphere(attackPoint.position, atatckRange);
    }

}
