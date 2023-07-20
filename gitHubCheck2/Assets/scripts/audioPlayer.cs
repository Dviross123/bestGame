using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    public AudioSource LoopSrc;
    public AudioSource NoLoopSrc;

    public AudioClip dashSfx, runSfx, sword1, sword2, sword3, boom, bowStrech, bip;

    public PlayerMovement playerMovement;
    public swordAttack swordAttack;
    public bowAttack bowAttack;
    public firstLetterAppear firstLetterAppear;

    private bool playDashSound = true;
    public bool playRunSound = true;
    private bool canPlayOthers;

    private float resetBipTimer;
    private float bipTimer;

    private void Start()
    {
        bipTimer = resetBipTimer;
    }
    private void swordAttack1()
    {
        NoLoopSrc.clip = sword1;
        NoLoopSrc.Play();
    }

    private void swordAttack2()
    {
        NoLoopSrc.clip = sword2;
        NoLoopSrc.Play();
    }

    private void swordAttack3()
    {
        NoLoopSrc.clip = sword3;
        NoLoopSrc.Play();
    }

    private void Boom()
    {
        NoLoopSrc.clip = boom;
        NoLoopSrc.Play();
    }

    private void BowStrech()
    {
        NoLoopSrc.clip = bowStrech;
        NoLoopSrc.Play();
    }

    private void Dash()
    {
        NoLoopSrc.clip = dashSfx;
        NoLoopSrc.Play();
    }

    private void Run()
    {
        LoopSrc.clip = runSfx;
        LoopSrc.Play();
    }

    private void Bip()
    {
        NoLoopSrc.clip = bip;
        NoLoopSrc.Play();
    }

    private void stopLoopSrc()
    {

        LoopSrc.Stop();
    }

    private void Update()
    {
        resetBipTimer = Random.Range(0.05f, .5f);
        bipTimer -= Time.deltaTime;

        if (swordAttack.isAttacking && swordAttack.attackNum == 1 && swordAttack.canPlaySwordAttack1 && canPlayOthers)
        {
            swordAttack1();
        }

        if (swordAttack.isAttacking && swordAttack.attackNum == 2 && swordAttack.canPlaySwordAttack2 && canPlayOthers)
        {
            swordAttack2();
        }

        if (swordAttack.isAttacking && swordAttack.attackNum == 3 && swordAttack.canPlaySwordAttack3 && canPlayOthers)
        {
            swordAttack3();

        }

        if (swordAttack.isAttacking && swordAttack.attackNum == 3 && swordAttack.canPlayBoom && canPlayOthers)
        {

            Boom();
        }

        if (bowAttack.canPlayStrech && canPlayOthers)
        {
            BowStrech();
        }

        if (firstLetterAppear.inTrigger)
        {
            if (bipTimer <= 0f)
            {
                Bip();
                bipTimer = resetBipTimer;
                canPlayOthers = false;
            }
        }
        else
        {
            canPlayOthers = true;
            stopLoopSrc();
        }



        //if (playerMovement.isDashing && playDashSound)
        //{
        //    Debug.Log("Dash");
        //    Dash();
        //    playDashSound = false;
        //}
        //else if (!playerMovement.isDashing && !playDashSound) 
        //{
        //    playDashSound = true;
        //}

        //if (playerMovement.horizontal != 0f && playerMovement.IsGrounded() && playRunSound)
        //{
        //    Run();
        //    Debug.Log("run");
        //    playRunSound = false;
        //}
        //else if (!playerMovement.IsGrounded()) 
        //{
        //    stopPlay();
        //    playRunSound = true;
        //}
    }
}