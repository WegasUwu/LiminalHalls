using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpsystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Text deathText;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount)
{
    currentHealth -= damageAmount;

    Debug.Log("Current Health: " + currentHealth);

    // Additional check for zero or negative health
    if (currentHealth <= 0)
    {
        Die();
    }
}
    // Update is called once per frame
    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }
     private void Die()
    {

        // Enable the death text
        deathText.gameObject.SetActive(true);
        deathText.text = "Вы не выдержали...";
        Invoke("DeactivatePlayer", 0.1f);

    }
}
