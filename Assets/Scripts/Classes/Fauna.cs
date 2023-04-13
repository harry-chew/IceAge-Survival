using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;

public class Fauna : MonoBehaviour, IFauna
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    private float reactionTime;


    //state
    private enum State { Idle, Walking, Fleeing, Hunting, Eating, Defecating };
    [SerializeField] private State state;

    //hunger
    [SerializeField] private int chompAmount;
    private float hungerTimer = 0.0f;
    private float hungerTick = 5.0f;
    private enum FoodType { Plants, Meat, Fish };
    [SerializeField] private FoodType food;
    [SerializeField] private int hunger;
    private int maxHunger;
    [SerializeField] private GameObject[] foods;
    [SerializeField] private Transform knownFoodSource;
    [SerializeField] private GameObject foodToEat;
    [SerializeField] private float[] distanceToFoods;

    private TimerC timer;

    private void Awake()
    {
        timer = new TimerC();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        state = State.Idle;
        maxHunger = Random.Range(40, 60);
        hunger = maxHunger / Random.Range(1,2);
        chompAmount = hunger / 2;
    }

    private void Update()
    {
        Hunger();

        StateMachine();
    }

    private void StateMachine()
    {
        switch (state)
        {
            case State.Idle:
                Roam();
                break;
            case State.Walking:
                WalkingCheck();
                break;
            case State.Fleeing:
                break;
            case State.Hunting:
                HuntingCheck();
                break;
            case State.Eating:
                break;
            case State.Defecating:
                break;
        }
    }

    private void Hunger()
    {
        if(hunger <= maxHunger / 3)
        {
            state = State.Hunting;
        } 

        hungerTimer += Time.deltaTime;
        if(hungerTimer > hungerTick)
        {
            hunger--;
            hungerTimer = 0.0f;
        }
        if(hunger <= 0)
        {
            Destroy(gameObject);
        }
    }

    private bool IsInFoodArea()
    {
        return Vector3.Distance(transform.position, knownFoodSource.position) <= 1.0f;
        /*
        if (Vector3.Distance(transform.position, knownFoodSource.position) <= 1.0f)
            return true;
        else
            return false;
        */
    }
    private void Roam()
    {
            //pick random point in space near animal
            Vector3 roam = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            //move to point in space
            state = State.Walking;
            MoveTo(roam);
    }

    private void WalkingCheck()
    {
        if(isAtDestination())
        {
            StartCoroutine(timer.TimeToWait(1.0f));
            state = State.Idle;
        }
    }

    private void HuntingCheck()
    {
        if (IsInFoodArea())
        {
            Eat();
        }
        else
        {
            MoveTo(knownFoodSource.position);
        }
    }
    public void MoveTo(Vector3 position)
    {
        navMeshAgent.SetDestination(position);
    }

    private bool isAtDestination()
    {
        
        if(navMeshAgent.remainingDistance <= 1f)
        {
            return true;
        } else
        { 
            return false;
        }
    }

    private void Hearing()
    {

    }


    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Defecate()
    {
        throw new System.NotImplementedException();
    }

    public void Eat()
    {
        state = State.Eating;

        //find nearest food item
        foods = GameObject.FindGameObjectsWithTag("Plant");
        StartCoroutine(timer.TimeToWait(1.0f));

        
        int pos = 0;
        /*
        for (int i = 0; i < foods.Length; i++)
        {
            distanceToFoods[i] = Vector3.Distance(transform.position, foods[i].transform.position);
            if (distanceToFoods[i] < distanceToFoods[pos]) { pos = i; }
        }
        */
        foodToEat = foods[pos];

        foodToEat.GetComponent<SmallPlant>().GetEaten(chompAmount);
        hunger += chompAmount /2;

        if(hunger > maxHunger / 3)
        {
            state = State.Idle;
        }
        StartCoroutine(timer.TimeToWait(1.0f));

        
    }



    public void Sleep()
    {
        throw new System.NotImplementedException();
    }
}
