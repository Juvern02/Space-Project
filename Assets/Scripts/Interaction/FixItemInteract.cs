using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FixItemInteract : MonoBehaviour, IInteractable
{
    public string itemName;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>(); // Assuming the inventory is on the Interactor's GameObject

        if (inventory != null)
        {
            // Call the method in the Inventory script to fix the item
            if (inventory.FixItem(itemName))
            {
                Canvas canvas = GetComponentInChildren<Canvas>();

                // Assuming the Text (TMP) is the first child of the canvas
                TextMeshProUGUI textComponent = canvas.GetComponentInChildren<TextMeshProUGUI>();

                // Assuming the Image is the second child of the canvas
                Image imageComponent = canvas.transform.GetChild(1).GetComponent<Image>();

                textComponent.gameObject.SetActive(false);
                imageComponent.gameObject.SetActive(true);

                return true;
            }
            
        }

        return false;
    }
}
