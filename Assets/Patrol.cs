using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour
{
    public Transform goal;
    public float speed = 0.075f;
    public float angleSpeed = 0.075f;
    public float distance = 1.5f;
    public GameObject[] waypoints;
    int nextWaypoint = 0;
    public Transform transform;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoints");
        for(int i=0; i< waypoints.Length; i++)
        {
            Debug.Log(waypoints[i].name + " " + waypoints[i].transform.position);

        }
    }

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.transform;
        
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        goal = waypoints[nextWaypoint].transform;
        Vector3 theGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
        Vector3 direction = theGoal - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), angleSpeed);

        Debug.DrawRay(transform.position, direction, Color.green);

        if (direction.magnitude >= distance)
            {
                Vector3 pushVector  = direction.normalized * speed;
            }
        
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
