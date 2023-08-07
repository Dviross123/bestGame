using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    private inventory inventory;
    public GameObject itemButton;

    public AudioSource NoLoopSrc;
    public AudioClip pickUpItemSound;

    private GameObject gameManager;

    public bool pickUpItem = false;

    private audioPlayer audioPlayer;


    //public GameObject effect;
    //remeber find with component from game object

    private void Start()
    {
        gameManager = GameObject.Find("gameManager");

        audioPlayer = gameManager.GetComponent<audioPlayer>();

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    private void Update()
    {
        
            
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                { // check whether the slot is EMPTY
                    
                    audioPlayer.PickUpItemSFX();
                    ;
                    inventory.isFull[i] = true; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with i               

                    Destroy(gameObject);
                    break;
                }
            }
        }

    }




}

