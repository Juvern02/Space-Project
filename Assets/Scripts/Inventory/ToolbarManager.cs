using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ToolbarManager : MonoBehaviour
{
    public GameObject InventorySlot;
    public InventorySystem inventorySystem;

    // Start is called before the first frame update
    void Start()
    {
        inventorySystem.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void OnUpdateInventory(){
        foreach(Transform t in transform){
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory(){
        foreach(InventoryItem item in inventorySystem.inventory){
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item){
        GameObject obj = Instantiate(InventorySlot);
        obj.transform.SetParent(transform.parent, false);

        SlotScript slot = obj.GetComponent<SlotScript>();
        slot.Set(item);
    }

}
