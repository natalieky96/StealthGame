using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDaddy : StateMachineBehaviour
{
    protected Transform transform;
    protected GameObject gameObject;
    protected StealthGameManager stateManager;
    protected UnityEngine.AI.NavMeshAgent agent;
    protected float speed = 0.075f;
    protected float angleSpeed = 0.075f;
    protected float distance = 1.5f;
    protected Transform goal;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.transform;
        gameObject = animator.gameObject;
        stateManager = gameObject.GetComponent<StealthGameManager>();
        goal = stateManager.target.transform;
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(goal.position);
    }
}
