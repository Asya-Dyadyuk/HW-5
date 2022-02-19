using UnityEngine;
using System.Threading;
using System;

public class PlayerMovment : MonoBehaviour
{
    public Animator animator;// will be used to control the Animator variables 
    public CharacterController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        animator.SetBool("WakeUp", true);
        DontDestroyOnLoad(gameObject); // to make the player apper in the level2
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //this piece of code will make the bandit to get up only once.
        Console.WriteLine(this.animator.GetCurrentAnimatorStateInfo(0).IsName("geteUp"));
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("getUp"))
            animator.SetBool("WakeUp", false);

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

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos(); //puts our player in the start position that we choose
    }

     void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }
}
