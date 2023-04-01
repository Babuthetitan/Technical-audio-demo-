using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtIdleBehaviour : StateMachineBehaviour
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
        if (Mathf.Abs(player.transform.position.x - animator.gameObject.transform.position.x) <= attackRange)
        {
            animator.SetTrigger("groundAtt");
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (Random.Range(0, 2) == 0)
            {
                animator.SetTrigger("skyAtt");
            }

            timer = 2;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveScript.enabled = false;
    }
}
