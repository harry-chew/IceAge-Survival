using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomFlush : MonoBehaviour, IInteractable
{
    public List<ICollectable> mushrooms = new List<ICollectable>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            mushrooms.Add(child.gameObject.GetComponent<ICollectable>());
        }
    }

    public ICollectable Interact()
    {
        ICollectable mushroom = transform.GetChild(0).GetComponent<ICollectable>();
        //transform.GetChild(0).GetComponent<ICollectable>()?.Collect();

        return mushroom;
    }




}
