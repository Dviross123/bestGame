using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{


    private inventory inventory;
    public swordAttack swordAttack;
    public int index;
    public bool isDroppingItem = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[index] = false;
        }
    }

    public void Cross()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<spawn>().SpawnItem();
            GameObject.Destroy(child.gameObject);
            
        }
    }


}