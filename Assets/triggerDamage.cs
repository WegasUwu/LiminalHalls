using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class triggerDamage : MonoBehaviour
{
    public GameObject PlayerGameObject;

    void OnTriggerEnter(Collider other)
{

    if (other.gameObject.CompareTag("Player"))
    {


        hpsystem playerHealth = PlayerGameObject.GetComponent<hpsystem>();

        // Additional null check within TakeDamage
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(20);
        }
        
    }
}}