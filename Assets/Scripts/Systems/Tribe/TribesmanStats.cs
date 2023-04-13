using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TribesmanStats : MonoBehaviour
{
    [SerializeField] private int hunger;
    [SerializeField] private int maxHunger;
    [SerializeField] private int resistance;
    [SerializeField] private int age;

    [SerializeField]
    private int health;
    private int maxHealth;

    [SerializeField]
    private float hungerTick = 10.0f;
    private float trackHungerTick = 0.0f;

    [SerializeField]
    private float moveSpeed;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(2f, 5f);
        navMeshAgent = GetComponent<NavMeshAgent>();
        this.navMeshAgent.speed = moveSpeed;

        maxHunger = Random.Range(50, 150);
        hunger = maxHunger / 2;

        maxHealth = Random.Range(50, 80);
        health = maxHealth;

        resistance = Random.Range(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        HandleHunger();
    }

    private void HandleHunger()
    {
        trackHungerTick += Time.deltaTime;

        if (trackHungerTick >= hungerTick)
        {
            hunger--;
            if(hunger <= maxHunger / resistance)
            {
                health--;
            }
            trackHungerTick = 0.0f;
        }
    }

    private void HandleHealth()
    {
        if(health <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        Destroy(gameObject);
    }
}
