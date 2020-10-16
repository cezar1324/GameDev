using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float moveSpeed;
    public float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        jumpHeight = 5;
        moveSpeed = 4;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = (new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight));
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = (new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y));
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = (new Vector2(-(moveSpeed), GetComponent<Rigidbody2D>().velocity.y));
        }


    }
}
