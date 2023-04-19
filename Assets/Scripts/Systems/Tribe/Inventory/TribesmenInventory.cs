using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribesmenInventory : MonoBehaviour
{
    //How much the individual Tribesman can carry
    [SerializeField]
    private float weightCapacity;

    //string = Item-name  float = item-weight
    //Total number of items can be calculated like this: /totalWeight in Inventory (of the same item)/ weight of the Item (singular))
    //Example: 1.6 (total Mushroom weight) / 0.2 (Weight of 1 Mushroom) = 8 Mushrooms in Inventory
    private Dictionary<string, float> inventory = new Dictionary<string, float>();
    
    public void AddItem(string itemName, float itemWeight)
    {
        weightCapacity -= itemWeight;

        if (!inventory.ContainsKey(itemName))
        {
            inventory.Add(itemName, itemWeight);
        }
        else
        {
            inventory[itemName] += itemWeight;
        }

        Debug.Log("Total weight of Mushrooms: " + inventory["Mushroom"]);
    }

    public float GetRemainingCapacity()
    {
        return weightCapacity;
    }
}
