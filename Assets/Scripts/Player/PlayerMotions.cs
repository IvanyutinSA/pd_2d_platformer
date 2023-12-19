using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotions : MonoBehaviour
{
    [SerializeField] LayerMask platformLayerMask;
    [SerializeField] private float speed = 9f;
    [SerializeField] private float jumpForce = 7f;

    private bool isGrounded = false;
    private Rigidbody2D rb;
    public Animator animator;
    float inputHorizontal;
    float inputVertical;
    float horizontalMove;
    bool facingRight = true;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if(inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        if(inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Update()
    {
        horizontalMove = inputHorizontal * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        isGrounded = collider.Length > 1;
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}