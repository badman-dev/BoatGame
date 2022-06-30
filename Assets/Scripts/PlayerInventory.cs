using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Transform> inventorySlotTransforms;

    public List<InventorySlot> inventorySlots;

    void Start()
    {
        for(int i = 0; i < inventorySlotTransforms.Count; i++)
        {
            inventorySlots.Add(new InventorySlot() { location = inventorySlotTransforms[i].localPosition });
        }
    }

    public void InventoryAdd(GameObject item)
    {
        //foreach(InventorySlot slot in inventorySlots)
        //{
        //    if (slot.item == null)
        //    {
        //        slot.item = item;

        //        item.transform.parent = transform;
        //        item.transform.localPosition = slot.location;

        //        break;
        //    }
        //}

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            InventorySlot slot = inventorySlots[i];

            if (slot.item == null)
            {
                slot.item = item;

                item.transform.parent = transform;
                item.transform.localPosition = slot.location;

                break;
            }
        }
    }

    [Serializable]
    public struct InventorySlot
    {
        public Vector3 location;
        public GameObject item;
    }
}
