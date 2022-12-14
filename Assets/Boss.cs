using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum bossState
    {
        BasicAttack,
        SpecialAttack,
        CloseFrontAttack,
        CloseBackAttack,
        FarFrontAttack,
        FarBackAttack,
        Defense,
        SpawnMob,
        WideAttack,
        Chase
    }
    bossState state = bossState.BasicAttack;

    private Player player;
    private Animator anim;
    private Vector3 distanceFromPlayer = new Vector3(0, 0, 0);
    private float fireBallShootDelay = 1.0f;
    private bool isClose, isFront;
    private int numAtk;
    private static float PATTERN_DELAY_TIME = 3.0f;
    public int bossSpeed;
    public int bossHP; 
    public GameObject fireball;
    public GameObject jaw;
    public GameObject mob;



    IEnumerator Start()
    {
        player = FindObjectOfType<Player>();
        anim = gameObject.GetComponent<Animator>();
        isClose = true;
        isFront = true;
        numAtk = 0;
        bossSpeed = 1;
        bossHP = 1000;

        while(true)
        {
            resetAnimBoolean();
            PlayBossPattern();
            yield return new WaitForSeconds(PATTERN_DELAY_TIME);
        }
    }

    void Update()
    {

    }

    private void CloseFrontCheck()
    {
        distanceFromPlayer = this.gameObject.transform.position - player.transform.position;
        if (distanceFromPlayer.magnitude < 20)
        {
            isClose = true;   
        }
        else
        {
            isClose = false;
        }

        if (distanceFromPlayer.z > 0)
        {
            isFront = true;
        }
        else
        {
            isFront = false;
        }
    }
    private void PlayBossPattern()
    {
        CloseFrontCheck();
        switch (state)
        {
            case bossState.BasicAttack:
                anim.SetBool("doBA", true);
                if (numAtk > 3)
                {
                    state = bossState.SpecialAttack;
                    break;
                }
                Debug.Log(state);
                if (isClose == true)
                {
                    if (isFront == true)
                    {
                        state = bossState.CloseFrontAttack;
                        break;
                    }
                    else
                    {
                        state = bossState.CloseBackAttack;
                        break;
                    }
                }
                else
                {
                    if (isFront == true)
                    {
                        state = bossState.FarFrontAttack;
                        break;
                    }
                    else
                    {
                        state = bossState.FarBackAttack;
                        break;
                    }
                }

            case bossState.SpecialAttack:
                anim.SetBool("doSA", true);
                if (numAtk == 0)
                {
                    state = bossState.BasicAttack;
                    break;
                }
                Debug.Log(state);
                if (numAtk != 0)
                {
                    int rndint = Random.Range(1, 4);
                    anim.SetInteger("specialAttackRndInt", rndint);
                    switch (rndint)
                    {
                        case 1:
                            state = bossState.Defense;
                            break;

                        case 2:
                            state = bossState.SpawnMob;
                            break;

                        case 3:
                            state = bossState.WideAttack;
                            break;
                    }
                }
                break;

            case bossState.CloseFrontAttack:
                
                anim.SetBool("doCFA", true);
                Debug.Log(state);
                numAtk += 1;
                state = bossState.BasicAttack;
                break;

            case bossState.CloseBackAttack:

                anim.SetBool("doCBA", true);
                Debug.Log(state);
                numAtk += 1;
                state = bossState.BasicAttack;
                break;

            case bossState.FarFrontAttack:

                anim.SetBool("doFFA", true);
                Debug.Log(state);
                Invoke("ShootFireBall", fireBallShootDelay);
                numAtk += 1;
                state = bossState.BasicAttack;
                break;

            case bossState.FarBackAttack:

                anim.SetBool("doFBA", true);
                Debug.Log(state);
                Invoke("SpreadFireBall", fireBallShootDelay);
                numAtk += 1;
                state = bossState.BasicAttack;
                break;

            case bossState.Defense:

                anim.SetBool("doDf", true);
                Debug.Log(state);
                numAtk = 0;
                state = bossState.SpecialAttack;
                break;

            case bossState.SpawnMob:
                SpawnMob();
                anim.SetBool("doSM", true);
                Debug.Log(state);
                numAtk = 0;
                state = bossState.SpecialAttack;
                break;

            case bossState.WideAttack:

                anim.SetBool("doWA", true);
                Debug.Log(state);
                numAtk = 0;
                state = bossState.SpecialAttack;
                break;
        }
    }
    private void ChasePlayer()
    {

    }
    private void ShootFireBall()
    {
        Instantiate(fireball, jaw.transform.position, jaw.transform.rotation);
    }

    private void SpreadFireBall()
    {
        Instantiate(fireball, jaw.transform.position, jaw.transform.rotation);
    }
    private void WideAttack()
    {

    }
    private void Defense()
    {

    }
    private void SpawnMob()
    {
        Instantiate(mob, new Vector3(
            Random.Range(transform.position.x - 30.0f, transform.position.x + 30.0f),
            10.0f,
            Random.Range(transform.position.z - 30.0f, transform.position.z + 30.0f)), transform.rotation);

        Instantiate(mob, new Vector3(
            Random.Range(transform.position.x - 30.0f, transform.position.x + 30.0f),
            10.0f,
            Random.Range(transform.position.z - 30.0f, transform.position.z + 30.0f)), transform.rotation);
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

    private void onHit()
    {
        bossHP -= 4;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            onHit();
            Destroy(other.gameObject);
        }
    }
}



