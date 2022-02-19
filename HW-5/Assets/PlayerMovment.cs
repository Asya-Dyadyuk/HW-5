using UnityEngine;
using System.Threading;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public Animator animator;// will be used to control the Animator variables 
    public CharacterController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    GameObject[] players;

    void Start()
    {
        animator.SetBool("WakeUp", true);
        if (SceneManager.GetActiveScene().name == "momo")
        {
            DontDestroyOnLoad(gameObject); // to make the player appear in the level2
        }
    }

    private void OnLevelWasLoaded(int level)
    {

        players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 1)
        {
            Destroy(players[1]);
        }
        FindStartPos(); //puts our player in the start position that we choose

    }

    void FindStartPos()
    {
        transform.position = GameObject.FindGameObjectWithTag("StartPos").transform.position;
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

    }

    public void onLanding()
    {
        animator.SetBool("Jump", false);
    }

    private void FixedUpdate()
    {
        //move.
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
