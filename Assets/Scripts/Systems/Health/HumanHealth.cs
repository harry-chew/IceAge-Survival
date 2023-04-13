using UnityEngine;

public class HumanHealth : MonoBehaviour, IHealth
{
    private int health;

    public void HealDamage(int heal)
    {
        health += heal;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
