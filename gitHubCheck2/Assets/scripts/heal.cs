using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    private GameObject player;
    public healthBar healthBar;
    public playerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }


    public void HealPlayer()
    {
        if(player.GetComponent<playerManager>().health < player.GetComponent<playerManager>().resetHealth)
        {
            player.GetComponent<playerManager>().health++;
            GameObject.Destroy(gameObject);
            healthBar.SetHealth(playerManager.health, playerManager.resetHealth);
        }
    }
}
