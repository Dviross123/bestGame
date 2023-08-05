using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healTemp : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }



    public void healthUp()
    {
       
        player.GetComponent<playerManager>().resetHealth = 15f;
        player.GetComponent<playerManager>().health += 5f;
        if (player.GetComponent<playerManager>().health >= 15f) 
        {
            player.GetComponent<playerManager>().health = 15f;
        }
        GameObject.Destroy(gameObject);

    }
}
