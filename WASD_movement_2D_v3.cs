using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class WASD_movement_2D_v3 : MonoBehaviour
{   public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D body;

    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        print("jumpmadeflase");
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        //if ((Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.W) && !isJumping) | (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.W) && !isJumping))
            //{
                //UnityEngine.Vector2 direction = new UnityEngine.Vector2(1,1).normalized;
               // body.velocity = moveSpeed * Time.deltaTime * direction;
                //isJumping = true;
            //}
        if (Input.GetKey(KeyCode.W) && !isJumping)
            {
                Vector2 direction = new(0, 1);
                body.velocity = jumpHeight * moveSpeed * direction;
                //print("wonly");
                isJumping = true;
            }
       // if ((Input.GetKeyDown(KeyCode.A) && !isJumping) | (Input.GetKeyDown(KeyCode.D) && !isJumping))
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))

            {
                if (Input.GetKey(KeyCode.A))
            {UnityEngine.Vector2 direction = new(-1*moveSpeed, body.velocity.y);
            body.velocity = direction;}

            else if (Input.GetKey(KeyCode.D))
            {UnityEngine.Vector2 direction = new(1*moveSpeed, body.velocity.y);
            body.velocity = direction;}
            //body.AddForce(new(Input.GetAxis("Horizontal")*moveSpeed, 0));
            }
       


        
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