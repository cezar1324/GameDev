using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    //Player movement and rigidbody 2d
    public Rigidbody2D rb;
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



    // Start is called before the first frame update
    void Start()
    {
        extraJumpsValue = 2;
        speed = 20.0f;
        jumpHeight = 5.0f;
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
        movePlayer(movement);
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
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = (new Vector2(speed, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement = (new Vector2(-speed, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps != 0)
        {
            movement = (new Vector2(0, jumpHeight));
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            movement = (new Vector2(0, jumpHeight));
        }
        else
        {
            movement = (new Vector2(0, 0));
        }
    }
    void movePlayer(Vector2 direction)
    {
        if (direction.y <= 0)
        {
            rb.AddForce(direction);

        }
        else
        {
            rb.AddForce(direction, ForceMode2D.Impulse);
        }
    }
}
