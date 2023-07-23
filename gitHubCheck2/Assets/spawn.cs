using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    private Transform player;
    public GameObject item;
    public PlayerMovement playerMovement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnItem()
    {

            Vector2 playerPos = new Vector2(player.position.x + 2, player.position.y + .5f);
            Instantiate(item, playerPos, Quaternion.identity);
    }
}