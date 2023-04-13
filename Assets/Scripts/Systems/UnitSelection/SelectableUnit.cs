using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SelectableUnit : MonoBehaviour
{
    private NavMeshAgent Agent;
    public GameObject Tribesmen;
    public Animator animator;
    [SerializeField]
    private SpriteRenderer SelectionSprite;

    private void Awake()
    {
        SelectionManager.Instance.AvailableUnits.Add(this);
        Agent = GetComponent<NavMeshAgent>();
        animator = Tribesmen.GetComponent<Animator>();
    }

    public void Update()
    {
        if (HasReachedDestination())
        {
            animator.SetBool("isWalking", false);    
        }
    }
    public void MoveTo(Vector3 Position)
    {
        Agent.SetDestination(Position);
        
        animator.SetBool("isWalking", true);
    }

    public bool HasReachedDestination()
    {
        if(!Agent.pathPending)
        {
            if(Agent.remainingDistance <= Agent.stoppingDistance)
            {
                if (!Agent.hasPath || Agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        return false;
    }

    public void OnSelected()
    {
        SelectionSprite.gameObject.SetActive(true);
    }

    public void OnDeselected()
    {
        SelectionSprite.gameObject.SetActive(false);
    }
}
