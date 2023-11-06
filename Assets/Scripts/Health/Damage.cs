using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int amount = -1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.GetComponent<Health>().Change(amount);
    }
}
