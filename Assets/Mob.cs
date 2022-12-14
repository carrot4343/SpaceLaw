using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private float moveSpeed;
    private float distanceFromPlayer;
    private bool isOnChase;
    private float mobHP;

    void Start()
    {
        player = FindObjectOfType<Player>();
        anim = this.gameObject.GetComponent<Animator>();
        distanceFromPlayer = (gameObject.transform.position - player.transform.position).magnitude;
        moveSpeed = 5.0f;
        mobHP = 40.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform);
        distanceFromPlayer = (gameObject.transform.position - player.transform.position).magnitude;
        anim.SetFloat("mobHP", mobHP);
        if(mobHP > 0)
        {
            checkChase();
        }
        else
        {
            Destroy(this.gameObject, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            mobHP -= 4;
            Destroy(other.gameObject);
        }
    }


    private void checkChase()
    {
        if (distanceFromPlayer > 3.5f)
        {
            anim.SetBool("doAttack", false);
            anim.SetBool("doChase", true);
            gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("doAttack", true);
            anim.SetBool("doChase" , false);
        }
    }
}
