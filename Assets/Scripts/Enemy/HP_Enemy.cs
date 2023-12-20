using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Enemy : MonoBehaviour
{
    [SerializeField] private int lives = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            Die();
        }
    }

    public void GetDamage()
    {
        Debug.Log("--hp");
        lives--;
        if (lives <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
