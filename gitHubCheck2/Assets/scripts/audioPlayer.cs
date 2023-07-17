using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    public AudioSource LoopSrc;
    public AudioSource NoLoopSrc;

    public AudioClip dashSfx, runSfx, sword1, sword2, sword3 , boom;
    public PlayerMovement playerMovement;
    public swordAttack swordAttack;
    private bool playDashSound=true;
    public bool playRunSound = true;

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

    private void stopPlay()
    {

        LoopSrc.Stop();
    }

    private void Update()
    {

        if (swordAttack.isAttacking && swordAttack.attackNum == 1 && swordAttack.canPlaySwordAttack1) 
        {
            swordAttack1();
        }

        if (swordAttack.isAttacking && swordAttack.attackNum == 2 && swordAttack.canPlaySwordAttack2)
        {
            swordAttack2();
        }

        if (swordAttack.isAttacking && swordAttack.attackNum == 3 && swordAttack.canPlaySwordAttack3)
        {
            swordAttack3();
          
        }

        if (swordAttack.isAttacking && swordAttack.attackNum == 3 && swordAttack.canPlayBoom)
        {
           
            Boom();
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
