using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtIdleBehaviour : StateMachineBehaviour
{
    public float timer;
    public float attackRange;
    Transform player;

    ExterminatorMove moveScript;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveScript = animator.gameObject.GetComponent<ExterminatorMove>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        moveScript.enabled = true;
        timer = 2;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Mathf.Abs(player.transform.position.x - animator.gameObject.transform.position.x) <= attackRange)
        {
            animator.SetTrigger("groundAtt");
          
            AkSoundEngine.PostEvent("ext_attack", animator.gameObject);

        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (Random.Range(0, 2) == 0)
            {
                animator.SetTrigger("skyAtt");

                AkSoundEngine.PostEvent("ext_teleport", animator.gameObject);
            }

            timer = 2;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveScript.enabled = false;
    }
}
