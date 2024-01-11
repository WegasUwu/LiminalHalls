using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectionManager : MonoBehaviour
{
    public Transform camTransform;
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;

    private void Awake()
    {
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit,10))
        {
            var selectionTransform = hit.transform;
            print(hit.transform.name);
            if (selectionTransform.GetComponent<InteractableObject>())
            {
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }

        }
    }
}