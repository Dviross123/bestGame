using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healTemp : MonoBehaviour
{
    private GameObject player;
    private GameObject healthBar;
    public static float oldHealth;
    private bool canHeal = true;
    public playerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        healthBar = GameObject.Find("Player health Canvas");
    }



    
    public void healUp()
    {
        if (canHeal)
        {
            temphealthUp();
        }

    }
    private void temphealthUp()
    {
        canHeal = false;
        oldHealth = player.GetComponent<playerManager>().health;
        player.GetComponent<playerManager>().health = player.GetComponent<playerManager>().resetHealth + 5;
        healthBar.GetComponent<healthBar>().SetHealth(player.GetComponent<playerManager>().health, player.GetComponent<playerManager>().resetHealth);
        player.GetComponent<playerManager>().STP();

        GameObject.Destroy(gameObject);

    }
}
