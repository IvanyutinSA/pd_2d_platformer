using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy_Passive : MonoBehaviour
{

    public UnityEngine.Transform player;// for player positioning 
    [SerializeField] private Health Health;
    //[SerializeField] private IWeapon IWeapon;

    public float speed = 3; // speed enemy  (Move)
    public float position_start = 3.4f; // move from start to fnish
    public float position_fnish = 18.3f;
    private bool movingForward = true; // forward direction assignment

    public float detectionRange = 0.8f;//  damage distance (damege)
                                       //    public int amount = -1;// damage
    private bool readiness_attack = true; // readiness to attack
    public float delay = 1f; // delay after impact

    public void Update()
    {
        if (EnemyNearby() && readiness_attack)
        {
            Attack();
        }

        else
        {
            Move();
        }
    }
    public bool EnemyNearby()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform; // for player positioning
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);// distance  player and the enemy

        return distanceToPlayer <= detectionRange;
    }


    public void Attack()
    {
        readiness_attack = false;
        AnimationsBeforeAttack();
        //IWeapon.Attack();
        Debug.Log("damage");
        Invoke("AnimationAfterAttack", delay);
    }

    private void AnimationsBeforeAttack()
    {

    }
    private void AnimationAfterAttack()
    {
        readiness_attack = true;
    }

    private void Move() //simple enemy movement
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
            }
        }
    }
}



