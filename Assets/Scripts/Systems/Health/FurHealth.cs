using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurHealth : MonoBehaviour, IHealth
{
    private int health;

    public void HealDamage(int heal)
    {
        health += heal;
    }

    public void TakeDamage(int damage)
    {
        health -= (int)(damage / 1.5f);
    }
}
