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
    float horizontalMove;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
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
}