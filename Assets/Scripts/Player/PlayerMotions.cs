using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotions : MonoBehaviour
{
    [SerializeField] LayerMask platformLayerMask;
    [SerializeField] private float speed = 9f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float attack = 1;

    public bool isAttacking = false;
    public bool isRecharged = true;

    public float attackRange;
    public LayerMask enemy;

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
        animator = GetComponent<Animator>();
        isRecharged = true;
        attackRange = 1; 
}

    private void FixedUpdate()
    {
        CheckGround();

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Update()
    {
        horizontalMove = inputHorizontal * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (!isAttacking && Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (!isAttacking && isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        if (Input.GetButton("Fire1"))
        {
            Attack();
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

    private void Attack()
    {
        if (isGrounded && isRecharged)
        {
            isAttacking = true;
            isRecharged = false;
            Debug.Log("attack");
            OnAttack();
            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());
        }
    }

    private void OnAttack()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.position, attackRange, enemy);
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("-hp");
            try { 
                colliders[i].GetComponent<HP_Enemy>().GetDamage(); 
            }
            catch
            {

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        rb = GetComponent<Rigidbody2D>();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rb.position, attackRange);
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        isAttacking = false;
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        isRecharged = true;
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1.5f);
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