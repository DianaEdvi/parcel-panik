using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    [SerializeField] private float horizontal;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float braking = 1f;

    [SerializeField] private float jumpForce = 10;
    [SerializeField] private bool isJumping = false;

    private Animator anim;
    
    private bool jump = false;

    private SpriteRenderer sprite;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        horizontalSpeed = rb.velocity.x;
        verticalSpeed = rb.velocity.y;

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (jump) {
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("Force applied");
            jump = false;
        }

        //flipping character based on input
        if (rb.velocity.x >= 0)
        {
            sprite.flipX = false;
        }
        else if (rb.velocity.x < 0){
            sprite.flipX = true;
        }

        //accelerate via addforce, first two if statements are for capping speed at max
        if (rb.velocity.x > maxSpeed) {

            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);

        } else if (rb.velocity.x < -maxSpeed) {

            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);

        }
        else {

            //check if braking
            if (horizontal > 0 && rb.velocity.x < 0)
            {
                rb.AddForce(new Vector2(horizontal * braking, 0), ForceMode2D.Impulse);
            }
            else if (horizontal < 0 && rb.velocity.x > 0)
            {
                rb.AddForce(new Vector2(horizontal * braking, 0), ForceMode2D.Impulse);
            }
            else { 
                //if not braking, use acceleration
                rb.AddForce(new Vector2(horizontal * acceleration, 0), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = true;
        }
    }
}
