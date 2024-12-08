using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
// set public variables
public class WASD_movement_2D_v3 : MonoBehaviour
{   public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D body;
    //set private variable
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    // Set initial state of variable isJumping
    {
        isJumping = false;
        print("jumpmadeflase");
    }

    // Update is called once per frame
    void Update()
    // 1. create variables associated with W A S D inputs (-x,+x, -y,+y)
    // 2. If W is pressed and is jumping is false then set a body velocity 'upwards'
    // 3. If A OR D is pressed, then if it was A set a negative x velocity, if it was D set a positive.
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.W) && !isJumping)
            {
                Vector2 direction = new(0, 1);
                body.velocity = jumpHeight * moveSpeed * direction;
                isJumping = true;
            }
    
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))

            {
                if (Input.GetKey(KeyCode.A))
            {UnityEngine.Vector2 direction = new(-1*moveSpeed, body.velocity.y);
            body.velocity = direction;}

            else if (Input.GetKey(KeyCode.D))
            {UnityEngine.Vector2 direction = new(1*moveSpeed, body.velocity.y);
            body.velocity = direction;}
            }
       

    //If it encounters the ground then set isjumping to False.
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {print("collision");
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            print("jumpmadefalse");
        }
    }
}
TEST EDIT