using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Uiapper : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        text.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {           
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.enabled = false;
        }
        
    }
}
