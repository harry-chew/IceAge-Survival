using UnityEngine;

public class TribesmenCollision : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            IInteractable thisInteractable = other.GetComponent<IInteractable>();
            if (thisInteractable == CurrentInteraction.Instance.GetInteractable())
            {
                thisInteractable.Interact();
            }
        }
    }
}
