using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public PlayerInventory inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.InventoryAdd(this.gameObject);
        }
    }
}
