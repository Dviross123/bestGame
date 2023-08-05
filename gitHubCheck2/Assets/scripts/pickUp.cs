using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    private inventory inventory;
    public GameObject itemButton;

    public bool pickUpItem = false;
    //public GameObject effect;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                { // check whether the slot is EMPTY
                    //Instantiate(effect, transform.position, Quaternion.identity);
                    Debug.Log("touch potion");
                    pickUpItem = true;
                    inventory.isFull[i] = true; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with i               

                    Destroy(gameObject);
                    break;
                }
            }
        }

    }


}

