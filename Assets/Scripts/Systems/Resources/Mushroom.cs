using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour, ICollectable
{
    public static Action<ICollectable> OnMushRoomPicked;

    private string itemName = "Mushroom";
    private float itemWeight = 0.2f; //test value
    public void Collect()
    {
        Debug.Log("We collected 1 mushroom");
        OnMushRoomPicked?.Invoke(this);
        Destroy(gameObject);
    }

    public string GetName()
    {
        return itemName;
    }

    public float GetWeight()
    {
        return itemWeight;
    }
}
