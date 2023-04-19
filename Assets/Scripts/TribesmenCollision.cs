using UnityEngine;

public class TribesmenCollision : MonoBehaviour
{
    private TribesmenInventory inventory;

    private void Awake()
    {
        inventory = GetComponent<TribesmenInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            IInteractable thisInteractable = other.GetComponent<IInteractable>();
            if (thisInteractable == CurrentInteraction.Instance.GetInteractable())
            {
                ICollectable item = thisInteractable.Interact();
                if(item.GetWeight() <= inventory.GetRemainingCapacity())
                {
                    inventory.AddItem(item.GetName(), item.GetWeight());
                    item.Collect();
                } else
                {
                    Debug.Log("Too Heavy");
                }
                    
            }
        }
    }
}
