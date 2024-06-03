using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jump;

    private float Move;
    public Rigidbody2D rb;

    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");    //move
        rb.velocity = new Vector2(speed * Move, rb.velocity.y); //move
        if (Input.GetButtonDown("Jump")  && isJumping==false) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
           //the below 2 functions help in knowing if the player is colliding with the floor or not
           // if the player is not colliding with the floor "DO NOT JUMP"
           // IF THE PLAYER IS COLLIDING WITH THE FLOOR THEN "JUMP"
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}
