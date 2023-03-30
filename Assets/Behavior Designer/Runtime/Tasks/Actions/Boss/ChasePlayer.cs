using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class ChasePlayer : Action
{
    public float speed = 0;
    private Vector3 destination;
    private float distanceFromDestination;
    public SharedTransform player;
    private float chaseTime;
    
    public Animator anim;
    public override void OnAwake()
    {
        chaseTime = 0.0f;
    }
    public override TaskStatus OnUpdate()
    {
        destination = player.Value.position;
        distanceFromDestination = (destination - gameObject.transform.position).magnitude;
        destination.y = 10.0f;
        chaseTime += Time.deltaTime;
        if(chaseTime > 5.0f)
        {
            chaseTime = 0.0f;
            return TaskStatus.Success;
        }
        

        if (distanceFromDestination < 10.0f)
        {
            return TaskStatus.Success;
        }

        resetAnimBoolean();
        anim.SetBool("doBA", true);
        transform.LookAt(destination);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(destination.x, 10.0f, destination.z), speed * Time.deltaTime);
        return TaskStatus.Running;
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
