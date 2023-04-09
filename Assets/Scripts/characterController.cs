using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;


    private Rigidbody2D rigidbody2D;

    private bool isGrounded, jumping, isWalkable = true;

    public bool hurted;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    [SerializeField] private bool isGrounded, jumping;

    public LayerMask interactableLayer;



    public static characterController Instance;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (isGrounded)
        {
            jumping = true;
        }

        animator.SetBool("hurt", hurted);




    }
    private void Interact()
    {
        NPCController.Instance.Interact();
    }
    public void HandleUpdate()

    {

        {



            if (isWalkable && !hurted)
            {

                float moveInput = Input.GetAxisRaw("Horizontal");
                animator.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
                rigidbody2D.velocity = new Vector2(moveInput * moveSpeed, rigidbody2D.velocity.y);

                if (Input.GetKey(KeyCode.Space) && isGrounded)
                {
                    isGrounded = false;

                    print("jump");
                    animator.SetTrigger("jump");
                    rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

                    print("jump");
                    AudioManager.Instance.PlaySFX("jump");
                    animator.SetTrigger("jump");
                    rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    jumping = false;


                }

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Interact();
                }
                animator.SetBool("isGrounded", isGrounded);
            }
            void OnCollisionEnter2D(Collision2D other)
            {
                if (other.gameObject.CompareTag("ground"))
                {
                    isGrounded = true;
                }

                if (other.gameObject.CompareTag("npc"))
                {
                    other.gameObject.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }
}
