using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotions : MonoBehaviour
{
    [SerializeField] LayerMask platformLayerMask;
    public float WalkSpeed;
    public float JumpPower;
    public long jumpSpan = 10000000;

    private long lastTimeJump = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        WalkSpeed = 10;
        JumpPower = 400;
        platformLayerMask = LayerMask.GetMask("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate((new Vector2(horizontalInput, 0))*Time.deltaTime*WalkSpeed);
    }

    bool IsGrounded()
    {
        var boxCollider2d = GetComponent<BoxCollider2D>();
        float extraHeight = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider2d.bounds.center,
            boxCollider2d.bounds.size,
            0f,
            Vector2.down,
            extraHeight,
            platformLayerMask
        );

        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    void Jump()
    {
        if (!IsGrounded())
        {
            return;
        }
        if (!(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)))
        {
            return;
        }
        long time = DateTime.Now.Ticks;
        if (time - lastTimeJump < jumpSpan)
        {
            return;
        }
        GetComponent<Rigidbody2D>().AddForce(Vector2.up*JumpPower);
        lastTimeJump = time;
    }
}
