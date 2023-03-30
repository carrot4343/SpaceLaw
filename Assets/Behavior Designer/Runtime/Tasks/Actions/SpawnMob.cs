using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
public class SpawnMob : Action
{
    public Animator anim;
    public override TaskStatus OnUpdate()
    {
        resetAnimBoolean();
        anim.SetBool("doSM", true);
        anim.SetInteger("specialAttackRndInt", 2);
        

        return TaskStatus.Success;
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
