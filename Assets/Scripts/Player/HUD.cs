using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite damageHeart;
    private GameObject player;
    private int curHp;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        curHp = player.GetComponent<Health>().GetCurrentLives();

        for (int i = 0; i < curHp; i++)
        {
            if (i < curHp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = damageHeart;
            }
        }
    }
}

 