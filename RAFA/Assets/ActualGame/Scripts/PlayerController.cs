using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float hmove;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool facingright = true;
    public Animator animator;
   




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hmove * speed, rb.velocity.y);
        if (hmove != 0)
        {
            animator.SetBool("isMoving", true);
        }else { animator.SetBool("isMoving", false); }
        if (!isGrounded())
        {
            animator.SetBool("landed", false);
        }
         

    }
    // Update is called once per frame
    void Update()
    {
        hmove = Input.GetAxis("Horizontal");
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            Fly();
            animator.SetBool("landed", true);

        }

        Fall();
        Flip();
        


    }

    private bool isGrounded()
    {
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);

        if (grounded) //&& !wasGrounded)
        {
            // animator.SetBool("isFalling", true);
            animator.SetBool("landed", true);
            animator.SetBool("isFalling", false);
            //wasGrounded = true;
        }
        /* else if (!grounded && wasGrounded)
         {
             animator.SetBool("landed", false);
             wasGrounded = false;
         }*/

        return grounded;

    }

    private void Flip()
    {
        if(facingright && hmove < 0f)
        {
            transform.Rotate(0f, 180f, 0f);
            facingright = false;
        }
        if (!facingright && hmove > 0f)
        {
            transform.Rotate(0f, 180f, 0f);
            facingright = true;
        }
    }

    private void Fly()
    {
        
        animator.SetBool("isFlying", true);
        
        
        

    }

    private void Fall()
    {
        if (!isGrounded() && rb.velocity.y<0f)
        {
            
            animator.SetBool("isFlying", false);
            animator.SetBool("isFalling", true);
            
        }
    }
    

}
