using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float m_Speed; //Movement Speed of the pg
    [SerializeField] public float m_JumpHeight; //How high is the jump 
    private Rigidbody2D m_Body;
    private Animator m_Anim;
    private bool grounded; //To see if the player is on the ground
    private float m_HorizontalInput;

    private void Awake()
    {
        //References for rigidbody and m_Animator from object
        m_Body = GetComponent<Rigidbody2D>();
        m_Anim = GetComponent<Animator>(); 
    }

    private void Update()
    {
        m_HorizontalInput = Input.GetAxis("Horizontal");    //When you press leftKeys -1, rightKeys +1
        m_Body.velocity = new Vector2(m_HorizontalInput * m_Speed, m_Body.velocity.y);  //Movement of the pg
        
        if(m_HorizontalInput < 0.001f)    //if he is facing left turn/flip left
            transform.localScale = new Vector3(-1,1,1);
        else if (m_HorizontalInput > 0.001f)  //else turn/flip right
            transform.localScale = new Vector3(1,1,1);

        if (Input.GetKey(KeyCode.Space) && grounded)    //If Space Key is pressed and the pg is not on the ground the pg is going to jump
            Jump(); //Calling Jump method

        m_Anim.SetBool("run", m_HorizontalInput != 0); //if the player is moving --> run is true, else is false
        //run is a parameters needed in the Animator
        m_Anim.SetBool("grounded", grounded); //if the player is not hitting the ground start jump Animation
    }

    private void Jump()
    {
        m_Body.velocity = new Vector2(m_Body.velocity.x, m_JumpHeight); //Move the pg above / jump
        m_Anim.SetTrigger("jump"); //Triggers for the jump animation
        grounded = false; //We are not touching the ground so its false
    }

    private void OnCollisionEnter2D(Collision2D collision)  //This check if this game Object is colliding with something
    {
        if(collision.gameObject.tag == "Ground")    //We are checking if its colliding an Object with the Tag: Ground
            grounded = true; //We are touching the ground so its true
    }

    public bool canAttack()
    {
        return grounded == true;
    }
}
