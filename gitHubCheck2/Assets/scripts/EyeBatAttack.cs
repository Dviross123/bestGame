using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBatAttack : MonoBehaviour
{
    private bool isAttacking = false;
    private bool isKilling = false;
    private bool canAttack = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private IEnumerator attack()
    {
        isAttacking = true;
        //start animation
        yield return new WaitForSeconds(0.15f);
        isKilling = true;
        yield return new WaitForSeconds(0.1f);
        isKilling = false;
        yield return new WaitForSeconds(1f);
        //stop animation
        isAttacking = false;
    }   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isKilling && canAttack)
        {
            player.GetComponent<playerManager>().takeDamage(1);
            canAttack = false;
        }
        else if (collision.CompareTag("Player") && !isAttacking)
        {
            StartCoroutine(attack());
            canAttack = true;
        }
    }
}
