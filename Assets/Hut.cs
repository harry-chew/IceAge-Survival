using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hut : MonoBehaviour, ISelectable
{
    //Action to call when the hut is selected
    public static Action<ISelectable> OnSelect;
    public static Action<ISelectable> OnDeselect;
    //on mouse down select the hut
    private void OnMouseUp()
    {
        Select();
    }
    public void Select()
    {
        //set the selected thing to this hut
        OnSelect?.Invoke(this);
    }

    public void Deselect()
    {
        OnDeselect?.Invoke(this);
    }
}