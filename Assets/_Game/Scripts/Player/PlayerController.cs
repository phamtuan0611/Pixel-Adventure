using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Button left, right;
    private bool moveLeft, moveRight;
    private float horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        //anim = CharacterManager.instance.anim;
        moveLeft = false;
        moveRight = false;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
        Debug.Log("Trai nhan");
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
        Debug.Log("Trai tha");

    }

    public void PointerDownRight()
    {
        moveRight = true;
        Debug.Log("Phai nhan");

    }

    public void PointerUpRight()
    {
        moveRight = false;
        Debug.Log("Phai tha");

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

                MovePlayer();


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

                ChangeDirection();
                
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

    private void FixedUpdate()
    {
        //theRB.velocity = new Vector2(horizontalMove, theRB.velocity.y);
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

    private void ChangeDirection()
    {
        if (theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -activeSpeed;
        }
        else if (moveRight)
        {
            horizontalMove = activeSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
    }

    public void PlayerJump()
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
            //anim.SetBool("isDoubleJumping", true);
            anim.SetTrigger("isDoubleJump");
        }
    }
}
