using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    Animator anim;
    bool trigger = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        agent.destination = target.transform.position;
        anim.SetFloat("Speed", agent.velocity.magnitude);
        if (GameObject.FindGameObjectsWithTag("Goal").Length  == 0)
        {
            if (trigger == true)//trigger를 두어서 update 루프 내에서 한번만 실행되게 함.
            {
                this.GetComponent<NavMeshAgent>().speed = 5.0f;
                trigger = false;
            }
        }
    }
}
