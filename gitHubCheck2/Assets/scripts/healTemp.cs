using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healTemp : MonoBehaviour
{
    private GameObject player;
    private GameObject healthBar;
    public float timeOfHeal = 3f;
    private bool canHeal = true;



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
            StartCoroutine(temphealthUp());

        }

    }
    private IEnumerator temphealthUp()
    {
        canHeal = false;
        player.GetComponent<playerManager>().health = player.GetComponent<playerManager>().resetHealth + 5;
        healthBar.GetComponent<healthBar>().SetHealth(player.GetComponent<playerManager>().health, player.GetComponent<playerManager>().resetHealth);
        
        yield return new WaitForSeconds(timeOfHeal);
        player.GetComponent<playerManager>().health = player.GetComponent<playerManager>().resetHealth;
        healthBar.GetComponent<healthBar>().SetHealth(player.GetComponent<playerManager>().health, player.GetComponent<playerManager>().resetHealth);
        GameObject.Destroy(gameObject);

    }
}
