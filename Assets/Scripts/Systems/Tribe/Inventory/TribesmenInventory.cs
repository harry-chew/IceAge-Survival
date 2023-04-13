using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribesmenInventory : MonoBehaviour
{
    [SerializeField] private int inventorySize = 5;
    
    private List<InventoryItem> inventory = new List<InventoryItem>();

    public void AddItemToInventory(InventoryItem item)
    {
        if (inventory.Count < inventorySize)
        {
            inventory.Add(new InventoryItem(item.itemName, item.itemWeight));
        }
    }
    
    public void RemoveItemFromInventory(InventoryItem item)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] == item)
            {
                inventory.RemoveAt(i);
                break;
            }
        }
    }

    public void RemoveAllItemsFromInventory()
    {
        inventory.Clear();
    }
    
}
