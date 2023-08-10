using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    private inventory inventory;
    public GameObject itemButton;

    private GameObject gameManager;
    private audioPlayer audioPlayer;

    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        bc2d = GetComponent<BoxCollider2D>();

        gameManager = GameObject.Find("gameManager");
        audioPlayer = gameManager.GetComponent<audioPlayer>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    audioPlayer.PickUpItemSFX();
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer"))
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            rb2d.freezeRotation = true;
            bc2d.isTrigger = true;
        }
    }

}
