using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    internal static object current;


    public List<InventoryItem> inventory {get; private set;}

    private void Awake() {
        current = this;
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData data){
        if (m_itemDictionary.TryGetValue(data, out InventoryItem value)){
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData data){
        if (m_itemDictionary.TryGetValue(data, out InventoryItem value)){
            value.AddToStack();
        }
        else{
            InventoryItem newItem = new InventoryItem(data);
            inventory.Add(newItem);
            m_itemDictionary.Add(data, newItem);
        }
    }

    public void Remove(InventoryItemData data){
        if (m_itemDictionary.TryGetValue(data, out InventoryItem value)){
            value.RemoveFromStack();

            if(value.stackSize == 0){
                inventory.Remove(value);
                m_itemDictionary.Remove(data);
            }
        }
    }
}
