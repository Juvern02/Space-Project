using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public InventoryItemData item;
    public InventorySystem inventory;

    public bool Interact(Interactor interactor)
    {
        
    inventory.Add(item);
    
    Destroy(gameObject);
    
    if (inventory != null)
        {
            // Access and print the items in the inventory list
            List<InventoryItem> items = inventory.inventory;

            foreach (InventoryItem item in items)
            {
                Debug.Log("Item Name: " + item);
                // Print other properties as needed.
            }
        }
        else
        {
            Debug.LogError("InventorySystem not found in the scene.");
        }


    return true;
  
    }
}
