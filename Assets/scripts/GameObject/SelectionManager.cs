using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectionManager : MonoBehaviour
{

    public static SelectionManager Instance { get; set; }


    public Transform camTransform;
    public bool onTarget;
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;

    private void Start()
    {
        onTarget = true;
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {

            Destroy(gameObject);


        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit,10))
        {
            var selectionTransform = hit.transform;
            if (selectionTransform.GetComponent<InteractableObject>() && selectionTransform.GetComponent<InteractableObject>().playerInRange)

                {
                onTarget = true;
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_Info_UI.SetActive(true);
                return;
                }
        }
        interaction_Info_UI.SetActive(false);
        onTarget = false;
    }
}