using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiapperAccept : MonoBehaviour
{
    public TextMeshProUGUI textGood;
    public TextMeshProUGUI textNotGood;
    public PlayerMovement PlayerMovement;

    private void Start()
    {
        textGood.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerMovement.isWallSliding)
        {
            textGood.enabled = true;
            textNotGood.enabled = false;
        }
        else if (collision.CompareTag("Player"))
        {
            textGood.enabled = false;
            textNotGood.enabled = true;
        }
        else 
        {
            textGood.enabled = false;
            textNotGood.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerMovement.isWallSliding)
        {
            textGood.enabled = true;
            textNotGood.enabled = false;
        }
        else if (collision.CompareTag("Player"))
        {
            textGood.enabled = false;
            textNotGood.enabled = true;
        }
        else
        {
            textGood.enabled = false;
            textNotGood.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textGood.enabled = false;
            textNotGood.enabled = false;
        }

    }
}
