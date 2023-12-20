using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy_Active : MonoBehaviour
{

    public float speed = 3; // speed enemy
    public float position_start = 95f; // move from start to fnish
    public float position_fnish = 110f;

    private bool movingForward = true; // forward direction assignment


    public UnityEngine.Transform player; // for player positioning
    [SerializeField] private Health Health;//hp

    public float detectionRange = 1.6f;//  damage distance
    public int amount = -2;  // damage
    private bool readiness_attack = true; // readiness to attack

    public float delay = 0.7f; // delay before impact
    public float cooldown = 1f; // delay after impact

    public Animator animator;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // for player positioning

        float distanceToPlayer = Vector3.Distance(transform.position, player.position); //checking the distance between the player and the enemy

        if (distanceToPlayer <= detectionRange) // player in the zone
        {
            if (readiness_attack)
            {
                readiness_attack = false;
                animator.SetBool("Attack", true);
                Invoke("Animation", 0.1f); //calling a method with a delay
            }
        }
        else
        {
            Move();
        }
    }
    private void Animation()
    {
        animator.SetBool("Attack", false);
        Invoke("Delay", delay);
    }

    private void Delay() //inflicts a home attack if the player does not leave the target area
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            Health.Change(amount);

        }

        Invoke("Cooldown", cooldown); //calling a method with a delay
        Move();
    }

    private void Cooldown()
    {
        readiness_attack = true;
    }

    private void Move() // simple enemy movement
    {
        if (movingForward)
        {
            if (transform.position.x < position_fnish)
            {
                transform.Translate(transform.right * speed * Time.deltaTime); // moving foward

            }
            else
            {
                movingForward = false;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
        else
        {
            if (transform.position.x > position_start)
            {
                transform.Translate(-transform.right * speed * Time.deltaTime); // movng back

            }
            else
            {
                movingForward = true;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
    }
}