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


    return true;
  
    }
}
