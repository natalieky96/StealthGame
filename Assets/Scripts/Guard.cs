using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public Transform goal;
    public float rotationSpeed = 0.03f;
    public float distance = 1.5f;
    public int runSpeed = 30;
    private UnityEngine.AI.NavMeshAgent agent;

    enum state 
    {
        Break,
        Patrol,
        Chase
    }

     void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(goal.position);
    }

    void breakState()
    {

    }

    void patrolState()
    {

    }

    void chaseState()
    {
    
        Vector3 theGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
        Vector3 direction = theGoal - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);

        Debug.DrawRay(transform.position, direction, Color.red);

        if (agent.remainingDistance >= agent.stoppingDistance)
            {
                agent.SetDestination(goal.position);
                return;
            }
        else
            {
                agent.isStopped = true;
            }    

    }


}



           