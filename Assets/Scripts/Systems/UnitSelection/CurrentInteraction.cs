using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentInteraction : MonoBehaviour
{
    public static CurrentInteraction Instance;
    
    private IInteractable current;

    //singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetCurrent(IInteractable interactable)
    {
        current = interactable;
        Debug.Log(current);
    }

    public IInteractable GetInteractable()
    {
        return current;
    }
}
