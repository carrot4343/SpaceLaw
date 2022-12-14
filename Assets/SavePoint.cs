using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 savePoint;
    void Start()
    {
        savePoint = this.gameObject.transform.localPosition;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            Stg_manager.instance.SetStartPoint(savePoint);
        }
    }
}
