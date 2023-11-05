using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy_Passive : MonoBehaviour
{

    public float speed = 3; // Скорость движения объекта
    public float position_start = 3.4f ; // каординаты от котроыой и до которой движиться объект
    public float position_fnish = 18.3f ;

    private bool movingForward = true; // Флаг, указывающий, двигается ли объект вперед

    private void Update()
    {
        if (movingForward)
        {
            if (transform.position.x < position_fnish)
            {
                transform.Translate(transform.right * speed * Time.deltaTime); // Движение вперед

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
                transform.Translate(-transform.right * speed * Time.deltaTime); // Движение back

            }
            else
            {
                movingForward = true;
            }
        }
    }
}
