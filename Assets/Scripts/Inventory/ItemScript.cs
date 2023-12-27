using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour, IInteractable
{
    public string itemName;
    public string itemType;
    public Sprite itemIcon;
    public Item item;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    // Start is called before the first frame update
    void Start()
    {
        //create a new item
        item = new Item();
  
        item.itemName = itemName;
        item.itemType = itemType;
        item.itemIcon = itemIcon;    
    }

    // Update is called once per frame
    public Item GetItem(){
        return item;
    }

    public bool Interact(Interactor interactor)
    {
        return true;
    }
}
