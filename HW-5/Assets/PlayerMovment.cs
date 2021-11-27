using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;
    public float runSpeed = 0.0000000000005f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
            jump = true;
        
        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;
    }

    private void FixedUpdate()
    {
        //move the mask
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
