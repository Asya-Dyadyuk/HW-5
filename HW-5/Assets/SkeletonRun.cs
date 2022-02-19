using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D  rigidbody;
    public float speed = 1.5f;
    public float attackRange = 3f;
    Enemy skeleton;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();

        skeleton = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //skeleton.LookAtPlayer();

        Vector2 terget = new Vector2(player.position.x, rigidbody.position.y);
        Vector2 newPos = Vector2.MoveTowards(rigidbody.position, terget, speed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPos);

        if(Vector2.Distance(player.position, rigidbody.position) <= attackRange)
        {
            animator.SetTrigger("Skeleton_Attacks");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Skeleton_Attacks");
    }


}
