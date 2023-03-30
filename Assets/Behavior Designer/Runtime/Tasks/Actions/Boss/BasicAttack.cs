using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class BasicAttack : Action
{
    public Animator anim;
    private Vector3 distanceFromPlayer = new Vector3(0, 0, 0);
    public SharedTransform player;
    private bool isClose, isFront;
    private SharedInt numAtk;
    public BehaviorTree bt;

    public override void OnAwake()
    {
        
    }
    public override TaskStatus OnUpdate()
    {
        resetAnimBoolean();

        CloseFrontCheck();
        if (isClose)
        {
            if (isFront)
            {
                anim.SetBool("doBA", false);
                anim.SetBool("doCFA", true);
            }
            else
            {
                anim.SetBool("doBA", false);
                anim.SetBool("doCBA", true);
            }
        }
        else
        {
            if (isFront)
            {
                anim.SetBool("doBA", false);
                anim.SetBool("doFFA", true);
            }
            else
            {
                anim.SetBool("doBA", false);
                anim.SetBool("doFBA", true);
            }
        }
        numAtk = (SharedInt)bt.GetVariable("numAtk");
        numAtk.Value += 1;
        gameObject.GetComponent<Behavior>().SetVariable("numAtk", numAtk);
        return TaskStatus.Success;
    }

    private void CloseFrontCheck()
    {
        distanceFromPlayer = this.gameObject.transform.position - player.Value.position;
        if (distanceFromPlayer.magnitude < 20)
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }

        if (distanceFromPlayer.z > 0)
        {
            isFront = true;
        }
        else
        {
            isFront = false;
        }
    }

    public void resetAnimBoolean()
    {
        anim.SetBool("doBA", false);
        anim.SetBool("doSA", false);
        anim.SetBool("doCFA", false);
        anim.SetBool("doCBA", false);
        anim.SetBool("doFFA", false);
        anim.SetBool("doFBA", false);
        anim.SetBool("doDf", false);
        anim.SetBool("doSM", false);
        anim.SetBool("doWA", false);
    }
}
