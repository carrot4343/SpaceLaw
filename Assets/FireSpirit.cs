using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireSpirit : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    private Vector3 destination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        destination = new Vector3(transform.position.x - target.transform.position.x, 0.0f, transform.position.z - target.transform.position.z).normalized;
        agent.SetDestination(transform.position + destination * 2.0f);
    }

}

