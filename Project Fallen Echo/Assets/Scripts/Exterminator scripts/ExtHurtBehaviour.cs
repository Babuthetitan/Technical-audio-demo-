using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtHurtBehaviour : StateMachineBehaviour
{
    public float timer;
    public float attackRange;
    Transform player;

    ExterminatorMove moveScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveScript = animator.gameObject.GetComponent<ExterminatorMove>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        moveScript.enabled = true;
        timer = 2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveScript.enabled = false;
    }
}
