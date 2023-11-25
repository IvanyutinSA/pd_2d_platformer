using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IWeapon
{
    int _damage;
    float _cooldown;

    public void Attack() {}
}


public class Wave : MonoBehaviour, IWeapon
{
    int _damage = -2;
    float _cooldown = 1f;
    float _range = 1.6f;
    float _lastUse = 0;
    public gameObject master;

    public void Attack() {        
        // Check if in cooldown

        var player = GameObject.FindGameObjectWithTag("Player").transform;
        float distanceToPlayer = Vector3.Distance(master.transform.position, player.position);

        if (distanceToPlayer < _range){
            Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>():
            Health.Change(_damage);
            OnCooldown();
        }
    }

    private void OnCooldown(){
        return;
    }
}


public class Wave : MonoBehaviour, IWeapon
{
    int _damage = -2;
    float _cooldown = 1f;
    float _range = 0.2f;
    float _lastUse = 0;
    public gameObject master;

    public void Attack() {        
        // Check if in cooldown

        var player = GameObject.FindGameObjectWithTag("Player").transform;
        float distanceToPlayer = Vector3.Distance(master.transform.position, player.position);

        if (distanceToPlayer < _range){
            Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>():
            Health.Change(_damage);
            OnCooldown();
        }
    }

    private void OnCooldown(){
        return;
    }
}
