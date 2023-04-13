using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlant : MonoBehaviour
{

    public void GetEaten(int chomp)
    {
        transform.localScale -= new Vector3(chomp / 100, chomp / 100, chomp / 100);

    }
    
}
