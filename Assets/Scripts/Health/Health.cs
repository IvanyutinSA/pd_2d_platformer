using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int lives = 5;
    [SerializeField] private int livesMax = 5;

    public void Change(int amount)
    {
        lives += amount;
        if (lives > livesMax)
        {
            lives = livesMax;
        }
        Debug.Log(lives);
        if (lives <= 0)
        {
            Debug.Log("Юнит погиб");
        }
    }
}
