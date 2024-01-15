using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerInRange;

    public string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange&&SelectionManager.Instance.onTarget)
       
            {
                Debug.Log("Подобранно");
                Destroy(gameObject);
                

            }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

        }
    }

}
