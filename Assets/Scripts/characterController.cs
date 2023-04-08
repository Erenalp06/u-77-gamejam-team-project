using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rigidbody2D;
    private bool isGrounded, jumping;
    

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update(){

        if(Input.GetAxisRaw("Horizontal") < 0){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }

        if(isGrounded){
            jumping = true;
        }

    }

    
    void FixedUpdate()
    {    

        float moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        rigidbody2D.velocity = new Vector2(moveInput * moveSpeed, rigidbody2D.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)){
            if(jumping){
                isGrounded = false;         
            print("jump");
            animator.SetTrigger("jump");
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumping = false;

            }
            
        }

        animator.SetBool("isGrounded", isGrounded);
        print("IsGrounded : " + isGrounded);
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground")){
            isGrounded = true;
        }
    }
}
