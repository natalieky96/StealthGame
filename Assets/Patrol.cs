using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateDaddy
{    
    public GameObject[] waypoints;
    int nextWaypoint = 0;
    public Transform wayPointGoal;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoints");
        for (int i = 0; i < waypoints.Length; i++)
        {
            Debug.Log(waypoints[i].name + " " +
                waypoints[i].transform.position);
        }
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wayPointGoal = waypoints[nextWaypoint].transform;

        Vector3 realGoal = new Vector3(wayPointGoal.position.x,
            transform.position.y, wayPointGoal.position.z);

        Vector3 direction = realGoal - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(direction), angleSpeed);


        if (direction.magnitude >= distance)
        {
            agent.SetDestination(wayPointGoal.position);
            return;
        }
        else
        {
            nextWaypoint++;
            if (nextWaypoint >= waypoints.Length)
            {
                nextWaypoint = 0;
            }
            nextWaypoint = Random.Range(0, waypoints.Length);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}