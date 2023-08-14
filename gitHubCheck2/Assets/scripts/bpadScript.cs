using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bpadScript : MonoBehaviour
{
    private GameObject playerMovement;
    [SerializeField] private float bouncePower;
    void Start()
    {
        playerMovement = GameObject.Find("Player");
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerMovement.GetComponent<PlayerMovement>().IsGrounded() && !playerMovement.GetComponent<PlayerMovement>().IsWalled())
        {
            playerMovement.GetComponent<PlayerMovement>().rb.velocity = new Vector2(playerMovement.GetComponent<PlayerMovement>().rb.velocity.x, 20f);
        }
        else if (collision.gameObject.tag == "Player" && playerMovement.GetComponent<PlayerMovement>().IsWalled())
        {
            playerMovement.GetComponent<PlayerMovement>().BouncingSpeed = bouncePower;
            playerMovement.GetComponent<PlayerMovement>().BouncingDirection = -playerMovement.GetComponent<PlayerMovement>().transform.localScale.x;
            playerMovement.GetComponent<PlayerMovement>().IsBouncing = true;
            playerMovement.GetComponent<PlayerMovement>().rb.velocity = new Vector2(playerMovement.GetComponent<PlayerMovement>().BouncingSpeed*playerMovement.GetComponent<PlayerMovement>().BouncingDirection, 20f);
            yield return new WaitForSeconds(0.5f);
            playerMovement.GetComponent<PlayerMovement>().IsBouncing = false;
        }
    }



}

