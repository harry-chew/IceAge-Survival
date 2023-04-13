using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public int itemWeight = 1;

    public InventoryItem(string itemName, int itemWeight)
    {
        this.itemName = itemName;
        this.itemWeight = itemWeight;
    }
}
