using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{


    private inventory inventory;
    public int index;

    private void Start()
    {

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.items[index] = 0;
        }
    }

    public void Cross()
    {

        foreach (Transform child in transform)
        {
            //child.GetComponent<spawn>().spawnItem();
            GameObject.Destroy(child.gameObject);
        }
    }

}