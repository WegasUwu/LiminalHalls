using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    private int health = 100;

    public int Health { get => health; set => health = value; }

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <0)
        {
            Destroy(gameObject);
        }
    }
}
