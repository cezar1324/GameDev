using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    //Player movement and rigidbody 2d
    private Rigidbody2D rb;
    public Vector2 movement;
    //----------------------------Checking speed and jump height
    public float speed;
    public float jumpHeight;
    //Check facing direction
    private bool facingRight;
    //------------------------------------Check for ground
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    //----------------------------------JUMPING
    public int extraJumps;
    public int extraJumpsValue;
    //-=--------------------------------Player input check
    string buttonPressed;



    // Start is called before the first frame update
    void Start()
    {
        extraJumpsValue = 3;
        speed = 10.0f;
        jumpHeight = 7.0f;
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {

        //check the input 
        checkMovementInput();
        //check facing direction
        checkFacingDirection();
    }
    void FixedUpdate()
    {

        //Check if player is grounded
        checkGround();
        //Move the player
        movePlayer();
    }
    void checkGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
    void checkFacingDirection()
    {
        if (movement.x > 0 && facingRight == false)
        {
            Flip();
        }
        else if (movement.x < 0 && facingRight == true)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
    //------------------------------MOVEMENT METHODS---------------------------------
    void checkMovementInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            buttonPressed = "D";
        }
        else if (Input.GetKey(KeyCode.A))
        {
            buttonPressed = "A";
        }
        else
        {
            buttonPressed = "None";

        }


        if (Input.GetKey(KeyCode.Space) && extraJumps != 0)
        {
            buttonPressed = "Space";
        }
        else if (Input.GetKey(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            buttonPressed = "Space";
        }
    }
    void movePlayer()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }


        if (buttonPressed == "D")
        {
            rb.AddForce(new Vector2(speed, rb.velocity.y));
        }
        else if (buttonPressed == "A")
        {
            rb.AddForce(new Vector2(-speed, rb.velocity.y));
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }


        if (buttonPressed == "Space" && extraJumps != 0)
        {
            rb.velocity = (new Vector2(rb.velocity.x, jumpHeight));
            extraJumps--;
        }
        else if (buttonPressed == "Space" && extraJumps == 0 && isGrounded)
        {
            rb.velocity = (new Vector2(rb.velocity.x, jumpHeight));
        }

    }
}
