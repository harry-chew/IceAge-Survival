using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour, ICollectable
{
    public static Action<ICollectable> OnMushRoomPicked;
    public void Collect()
    {
        OnMushRoomPicked?.Invoke(this);
        Destroy(gameObject);
    }
}
