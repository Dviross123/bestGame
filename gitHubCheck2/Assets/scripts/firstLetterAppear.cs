using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstLetterAppear : MonoBehaviour
{
    public GameObject canvas;
    public bool inTrigger;

    public float destroyTimer;

    private void Start()
    {
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (inTrigger) 
        {
            destroyTimer -= Time.deltaTime;
            
        }

        if(destroyTimer <= 0f) 
        {
            InTriggerFalse();
        }


        if (Input.GetKey(KeyCode.Escape))
        {
            InTriggerFalse();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTrigger = true;
            canvas.SetActive(true);
        }
    }

    public void InTriggerFalse() 
    {
        canvas.SetActive(false);
        Destroy(gameObject);
        inTrigger = false;
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        canvas.SetActive(false);
    //        Destroy(gameObject);
    //        inTrigger = false;
    //    }
    //}
}