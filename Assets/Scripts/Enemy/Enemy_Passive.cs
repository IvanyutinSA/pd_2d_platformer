using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy_Passive : MonoBehaviour
{

    public float speed = 3; // speed enemy
    public float position_start = 3.4f; // move from start to fnish
    public float position_fnish = 18.3f;

    private bool movingForward = true; // forward direction assignment


    public UnityEngine.Transform player;// for player positioning
    [SerializeField] private Health Health;//hp


    public float detectionRange = 0.8f;//  damage distance
    public int amount = -1;// damage
    private bool readiness_attack = true; // readiness to attack

    public float delay = 1f; // delay after impact

    public Animator animator;//animator

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // for player positioning

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);//checking the distance between the player and the enemy

        if (distanceToPlayer <= detectionRange) // player in the zone
        {
            if (readiness_attack) //attack when ready
            {
                Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
                Health.Change(amount);
                readiness_attack = false;
                Invoke("Delay", delay); //calling a method with a delay 
            }
        }
        else
        {
            Move();
        }
    }

    private void Delay() //attack delay
    {
        readiness_attack = true;
        Move();
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