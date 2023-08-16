using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public playerManager playerManager;
    public PlayerMovement player;

    private bool canDamage = true;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDamage)
        {
            playerManager.takeDamage(1);
            StartCoroutine(playerManager.playerHit(player.transform.localScale.x));
            if(!player.isDashing) player.canDash = true;
            player.Jumps = 0;
            StartCoroutine(damageWait());
        }
    }

    private IEnumerator damageWait()
    {
        canDamage = false;
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }
}
