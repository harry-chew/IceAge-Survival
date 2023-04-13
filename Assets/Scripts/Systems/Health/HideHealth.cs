using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHealth : MonoBehaviour, IHealth
{
    private int health;
    private int armorRating;
    public void HealDamage(int heal)
    {
        health += heal;
    }

    public void TakeDamage(int damage)
    {
        if(damage >= armorRating)
        {
            health -= damage;
        }
    }
}
