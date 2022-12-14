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
            if (trigger == true)//trigger�� �ξ update ���� ������ �ѹ��� ����ǰ� ��.
            {
                this.GetComponent<NavMeshAgent>().speed = 5.0f;
                trigger = false;
            }
        }
    }
}
