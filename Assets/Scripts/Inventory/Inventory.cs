using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    List<Item> inventoryList;

    // delegate event for inventory updates
    public delegate void inventoryDelegate();
    public static event inventoryDelegate OnInventoryChange;

    // Start is called before the first frame update
    void Start()
    {
        inventoryList = new List<Item>();

        SpeedUpScript = GetComponent<AbilitySpeedUp>();
        JumpHighScript =  GetComponent<AbilityJumpHigh>();  

    }

    public List<Item> GetInventoryList()
    {
        return inventoryList;
    }

    public void AddItem(Item item)
    {
        //if inventory is empty add item
        if (inventoryList.Count == 0)
        {
            inventoryList.Add(item);
            EnableAbilityScripts(item);
        }
        else //inventory is not empty
        {
            bool inList = false; //bool for when item has been added

            foreach (Item i in inventoryList) 
            {
                if(item.itemName == i.itemName) //if there is an item with the same name
                {                               //just increase stacksize
                    i.stackSize++;
                    inList = true;
                }
            }

            if (!inList)   //so, if it's can't be stacked, add the item to List
            {
                inventoryList.Add(item);
                EnableAbilityScripts(item);
            }
        }
    
        OnInventoryChange?.Invoke(); //null reference check, then invoke event
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") 
        {
            ItemScript otherItemScript = other.GetComponent<ItemScript>();
            Item otherItem = otherItemScript.GetItem();

            AddItem(otherItem);

            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
        }
    }

    AbilitySpeedUp SpeedUpScript;
    AbilityJumpHigh JumpHighScript;

    //method to setActive ability scripts for items that are in inventory
    void EnableAbilityScripts(Item item)
    {
        if (item.itemName == "Cube")
        {
        //    Debug.Log("Enable Soda ability");
            SpeedUpScript.enabled = true;
        } else if (item.itemName == "Capsule")
        {
        //    Debug.Log("Enable Pill ability");
            JumpHighScript.enabled = true;
        }
    }

    void DisableAbilityScripts(Item item)
    {
        if (item.itemName == "Cube")
        {
        //    Debug.Log("Disable Soda ability");
            SpeedUpScript.enabled = false;
        }
        else if (item.itemName == "Capsule")
        {
        //    Debug.Log("Disable Pill ability");
            JumpHighScript.enabled = false;
        }
    }

    //static bool for when ability is active and thus can be activated
    public static bool AbilityIsActive = false;

    //abilities triggering
    private void Update()
    {   //if something in inventory check for keyboard input
        //convert to events
     
            if (Keyboard.current.digit1Key.wasPressedThisFrame && inventoryList.Count>0 && !AbilityIsActive)
            {
                if (inventoryList[0].itemType == "Ability"){
                    AbilityIsActive = true;
                    CheckWhichAbilityToActivate(0);
                    RemoveItem(0);
                }                
                //check which item is slot 0
                //depending on which item, activate the corresponding ability
            //    Debug.Log("1 pressed");
            }
            if (Keyboard.current.digit2Key.wasPressedThisFrame && inventoryList.Count>1 && !AbilityIsActive)
            {
                if (inventoryList[1].itemType == "Ability"){
                    AbilityIsActive = true;
                    CheckWhichAbilityToActivate(1);
                    RemoveItem(1);
                }
            }
            if (Keyboard.current.digit3Key.wasPressedThisFrame && inventoryList.Count>2 && !AbilityIsActive)
            {
                if (inventoryList[2].itemType == "Ability"){
                    AbilityIsActive = true;
                    CheckWhichAbilityToActivate(2);
                    RemoveItem(2);
                }

            }
            if (Keyboard.current.digit4Key.wasPressedThisFrame && inventoryList.Count>3 && !AbilityIsActive)
            {
                if (inventoryList[3].itemType == "Ability"){
                    AbilityIsActive = true;
                    CheckWhichAbilityToActivate(3);
                    RemoveItem(3);
                }

            }
            if (Keyboard.current.digit5Key.wasPressedThisFrame && inventoryList.Count>4 && !AbilityIsActive)
            {
                if (inventoryList[4].itemType == "Ability"){
                    AbilityIsActive = true;
                    CheckWhichAbilityToActivate(4);
                    RemoveItem(4);
                }

            }
            if (Keyboard.current.digit6Key.wasPressedThisFrame && inventoryList.Count>5 && !AbilityIsActive)
            {
                if (inventoryList[5].itemType == "Ability"){
                    AbilityIsActive = true;
                    CheckWhichAbilityToActivate(5);
                    RemoveItem(5);
                }

            }
            
        
    }

    void CheckWhichAbilityToActivate(int i)
    {
        Item itemToCheck = inventoryList[i];

        if (itemToCheck.itemName == "Cube")
        {
          //  Debug.Log("Speed up");
            SpeedUpScript.ActivateSpeedUp();
        } else if (itemToCheck.itemName == "Capsule")
        {
            JumpHighScript.ActivateJumpHigh();
          //  Debug.Log("Super Jump");
        }
    }

    //remove items from inventory (after they are used)
    void RemoveItem(int i) 
    {
        Item itemToRemove = inventoryList[i];
       
        //if it's the last of the stack, then remove the item and disable the ability
        if (itemToRemove.stackSize == 1)
        {
            inventoryList.Remove(itemToRemove);
            
            if(itemToRemove.itemType == "Ability"){
                DisableAbilityScripts(itemToRemove);
            }
        } else if (itemToRemove.stackSize > 1)
        {
            //if it's not the last of the stack, then just decrement the stacksize
            itemToRemove.stackSize--;
        }
        OnInventoryChange?.Invoke(); //null reference check, then invoke event
    }

}