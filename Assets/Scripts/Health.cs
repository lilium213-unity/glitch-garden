using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void DealDamage(float damage)
    {
        health -= damage;
        AmIDead();
    }

    private void AmIDead()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
