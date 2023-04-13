using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class SelectionController : MonoBehaviour
{
    [SerializeField] private ISelectable selectedThing;

    private void OnEnable()
    {
        Hut.OnSelect += SelectThing;
        Hut.OnDeselect += DeselectThing;
    }
    private void OnDisable()
    {
        Hut.OnSelect -= SelectThing;
        Hut.OnDeselect -= DeselectThing;
    }

    private void SelectThing(ISelectable hut)
    {
        //if there is a selected thing, deselect it
        if (selectedThing != null)
        {
            selectedThing = null;
        }
        //set the selected thing to the hut
        selectedThing = hut;
    }
    private void DeselectThing(ISelectable hut)
    {
        //if the hut is the selected thing, set the selected thing to null
        if (selectedThing == hut)
        {
            selectedThing = null;
        }
    }
}




