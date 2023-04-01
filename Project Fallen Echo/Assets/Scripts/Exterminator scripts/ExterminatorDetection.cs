using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExterminatorDetection : MonoBehaviour
{
    [SerializeField] float aggroRange;

    Vector2 playerPos;

    Transform playerTrans;
    Animator anim;

    private void Start()
    {
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        playerPos = playerTrans.position;

        if (Mathf.Abs(((Vector2)transform.position - playerPos).magnitude) > aggroRange)
        {
            return;
        }

        anim.SetBool("isAwake", true);
        this.enabled = false;
    }
}
