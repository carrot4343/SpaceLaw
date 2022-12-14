using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 bulletDirection;
    private float bulletSpeed = 1500.0f;
    Player player;
    Gun gun;
    void Start()
    {
        player = FindObjectOfType<Player>();
        gun = FindObjectOfType<Gun>();
        Destroy(this.gameObject, 3.0f);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        gameObject.transform.eulerAngles = new Vector3(gun.transform.eulerAngles.x-90.0f, player.transform.rotation.y, player.transform.eulerAngles.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
