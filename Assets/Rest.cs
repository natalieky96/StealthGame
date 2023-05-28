using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : StateDaddy
{
   public GameObject restPoint;
    public Transform restPointGoal;

 void Awake()
    {
        restPoint = GameObject.FindGameObjectWithTag("restPoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        restPointGoal = restPoint.transform;

        Vector3 realGoal = new Vector3(restPointGoal.position.x,
            transform.position.y, restPointGoal.position.z);

        Vector3 direction = realGoal - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), angleSpeed);


        if (direction.magnitude >= distance)
        {
            Vector3 pushVector = direction.normalized * speed;
            transform.Translate(pushVector, Space.World);
        }
    }
}
