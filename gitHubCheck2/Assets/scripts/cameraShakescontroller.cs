using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShakescontroller : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement ;
    public playerManager playerManager;
    public killSlime killSlime;
    public swordAttack swordAttack;


    void Start()
    {
  
    }
    void Update()
    {

        if ((playerMovement.isDashing /*&& !playerMovement.IsGrounded()*/) || playerMovement.IsSliding )
        {
            animator.SetBool("playerDash", true);

        }

        else
        {
            animator.SetBool("playerDash", false);
        }

        if (swordAttack.hitEnemy)
        {
            animator.SetBool("hitEnemy", true);
        }
        else 
        {
            animator.SetBool("hitEnemy", false);
        }




    }

}
