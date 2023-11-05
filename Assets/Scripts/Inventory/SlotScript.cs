using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;
    [SerializeField]
    private GameObject stackObj;

    public void Set(InventoryItem item){
        label.text = item.data.displayName;
        if (item.stackSize <=1)
        {
            stackObj.SetActive(false);
            return;
        }

    }
}
