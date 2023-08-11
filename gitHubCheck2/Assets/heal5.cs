using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal5 : MonoBehaviour
{
    private GameObject player;
    private GameObject healthBar;

    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.Find("Player");
        healthBar = GameObject.Find("Player health Canvas");

    }


    public void HealPlayer()
    {
        if (player.GetComponent<playerManager>().health < player.GetComponent<playerManager>().resetHealth)
        {
            player.GetComponent<playerManager>().health+=5;
            healthBar.GetComponent<healthBar>().SetHealth(player.GetComponent<playerManager>().health, player.GetComponent<playerManager>().resetHealth);
            GameObject.Destroy(gameObject);
        }
    }

}
