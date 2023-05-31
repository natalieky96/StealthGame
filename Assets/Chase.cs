using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : StateDaddy
{
    //private FMOD.Studio.EventInstance instance;
    //public FMODUnity.StudioEventEmitter fmodEventSees;
    //public FMODUnity.StudioEventEmitter ChaseEvent;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        //instance= FMODUnity.RuntimeManager.CreateInstance(ChaseEvent);
        //fmodEventSees.Play();
        //ChaseEvent.Play();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 realGoal = new Vector3(goal.position.x,
            transform.position.y, goal.position.z);

        Vector3 direction = realGoal - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), angleSpeed);


        if (agent.remainingDistance >= agent.stoppingDistance)
        {
            agent.SetDestination(goal.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        //ChaseEvent.Stop();
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