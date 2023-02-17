using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] int heath = 50;
    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null){
            Debug.Log("nhan vat k co dame");
            TakeDame(damageDealer.GetDamage());
            // heath -=damage.GetDamage();
            damageDealer.Hit();
        }
    }

     void TakeDame(int damageValue)
    {   
        heath -= damageValue;
        Debug.Log(heath);
        if(heath <= 0){
            Debug.Log(heath);
            Destroy(gameObject);
        }

    }
}
