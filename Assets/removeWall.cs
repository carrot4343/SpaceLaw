using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeWall : MonoBehaviour
{
    public GameObject destroyObject;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(destroyObject);
            Destroy(this.gameObject);
        }
    }
}
