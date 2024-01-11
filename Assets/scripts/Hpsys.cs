using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpsys : MonoBehaviour
{


    public int maxHealth = 100;
    public int currentHealth;
    public healthbarScript healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }
}
