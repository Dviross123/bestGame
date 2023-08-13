using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMountainButton : MonoBehaviour
{
    public GameObject canvasTrigger;
    public GameObject mountainenter;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            canvasTrigger.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) 
            {
               Destroy(mountainenter); 
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvasTrigger.SetActive(false);
    }
}
