using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<InventorySlot> inventorySlots;

    public void InventoryAdd(GameObject item, InventorySlot slot)
    {
        slot.item = item;

        item.transform.parent = slot.transform;
        item.transform.localPosition = Vector3.zero;

        //for (int i = 0; i < inventorySlots.Count; i++)
        //{
        //    InventorySlot slot = inventorySlots[i];

        //    if (slot.item == null)
        //    {
        //        slot.item = item;

        //        item.transform.parent = slot.transform;
        //        item.transform.localPosition = Vector3.zero;

        //        break;
        //    }
        //}
    }

    public void InventoryRemove(GameObject item)
    {
        Debug.Log("inven remove");
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            InventorySlot slot = inventorySlots[i];

            if (slot.item == item)
            {
                Debug.Log("same item found in " + i);
                slot.item = null;
                break;
            }
        }
    }

    //[Serializable]
    //public struct InventorySlot
    //{
    //    public Vector3 location;
    //    public GameObject item;
    //}
}
