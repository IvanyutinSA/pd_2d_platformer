using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy_Passive : MonoBehaviour
{

    public float speed = 3; // �������� �������� �������
    public float position_start = 3.4f ; // ���������� �� �������� � �� ������� ��������� ������
    public float position_fnish = 18.3f ;

    private bool movingForward = true; // ����, �����������, ��������� �� ������ ������

    private void Update()
    {
        if (movingForward)
        {
            if (transform.position.x < position_fnish)
            {
                transform.Translate(transform.right * speed * Time.deltaTime); // �������� ������

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
                transform.Translate(-transform.right * speed * Time.deltaTime); // �������� back

            }
            else
            {
                movingForward = true;
            }
        }
    }
}
