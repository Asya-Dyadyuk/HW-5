using UnityEngine;
using System.Threading;

public class PlayerMovment : MonoBehaviour
{
    public Animator animator;// will be used to control the Animator variables 
    public CharacterController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //change the variable "Speed" and use the value of horizontalMove, abs is for the direction.
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
        if (Input.GetButtonDown("Crouch"))
           crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;
    }

    public void onLanding()
    {
         animator.SetBool("Jump", false);
    }

    private void FixedUpdate()
    {
        //move.
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
