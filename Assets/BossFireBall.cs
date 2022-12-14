using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireBall : MonoBehaviour
{

    private float distanceFromPlayer;
    private Vector3 playerDirection;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        distanceFromPlayer = (player.transform.position - this.transform.position).magnitude;
        playerDirection = player.transform.position - transform.position;
        Debug.Log(distanceFromPlayer);
        gameObject.GetComponent<Rigidbody>().AddForce(playerDirection.normalized * distanceFromPlayer * distanceFromPlayer * 1.2f);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = (player.transform.position - this.transform.position).magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(distanceFromPlayer);
        if(distanceFromPlayer < 8.0f)
        {
            Stg_manager.instance.decreaseLife();
        }
        Destroy(this.gameObject);
    }
}
