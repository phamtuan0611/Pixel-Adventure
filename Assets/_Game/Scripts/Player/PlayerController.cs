using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Rigidbody2D theRB;
    [SerializeField] private float jumpForce;
    //SerializeField] private float runSpeed;
    private float activeSpeed;

    private bool isGrounded;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    private bool canDoubleJump;

    [SerializeField] private Animator anim;

    [SerializeField] private float knockbackLength, knockbackSpeed;
    private float knockbackCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale <= 0f)
            return;
        else
        {
            activeSpeed = moveSpeed;

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

            if (knockbackCounter <= 0)
            {
                //Move
                theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * activeSpeed, theRB.velocity.y);

                //Jump
                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded == true)
                    {
                        Jump();
                        canDoubleJump = true;
                        anim.SetBool("isDoubleJumping", false);
                    }
                    else if (canDoubleJump == true)
                    {
                        Jump();
                        canDoubleJump = false;
                        anim.SetTrigger("isDoubleJump");
                    }
                }

                //ChangeDirection
                if (theRB.velocity.x > 0)
                {
                    transform.localScale = Vector3.one;
                }
                if (theRB.velocity.x < 0)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
            else
            {
                knockbackCounter -= Time.deltaTime;
                theRB.velocity = new Vector2(knockbackSpeed * -transform.localScale.x, theRB.velocity.y);
            }

            anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
            anim.SetBool("isGrounded", isGrounded);
            anim.SetFloat("ySpeed", theRB.velocity.y);
        }
    }

    public void Jump()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
    }

    public void isKnock()
    {
        theRB.velocity = new Vector2(0f, jumpForce * 0.5f);
        anim.SetTrigger("isKnocking");
        knockbackCounter = knockbackLength;
    }
}
