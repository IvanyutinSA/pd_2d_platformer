using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int lives = 5;
    [SerializeField] private int livesMax = 5;
    [SerializeField] private bool isLive = true;
    public Animator animator;

    private void Awake()
    {
    }

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
            isLive = false;
            animator.SetTrigger("Death");
            Invoke("PlayerDie", 1.1f);
            //PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Debug.Log("Object destroyed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetCurrentLives() { return lives; }
    public int GetMaxLives() { return livesMax; }
    public bool IsLive { get {  return isLive; } }
}

