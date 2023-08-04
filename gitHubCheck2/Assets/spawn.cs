using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    private Transform player;
    public GameObject item;
    private GameObject playerMovement;
  //  public GameObject slot;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = GameObject.Find("Player");
    }
    private void Update()
    {
        //if(slot.transform.GetChild(0)!= null)
        //{
        //    item = slot.transform.GetChild(0).gameObject;
        //}
       
    }

    public void SpawnItem()
    {
        Debug.Log("a");
        if (playerMovement.GetComponent<PlayerMovement>().isFacingRight)
        {
            Vector2 playerPos = new Vector2(player.position.x + 2f, player.position.y + .5f);
            Instantiate(item, playerPos, Quaternion.identity);

        }
        else
        { 
            Vector2 playerPos = new Vector2(player.position.x - 2f, player.position.y + .5f);
            Instantiate(item, playerPos, Quaternion.identity);
        }
        
    }
}