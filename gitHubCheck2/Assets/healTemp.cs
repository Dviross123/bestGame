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


    public void HealPlayerTemp()
    {
        StartCoroutine(temphealthUp());
        
    }
    private IEnumerator temphealthUp()
    {
        float oldHealth = player.GetComponent<playerManager>().health;
        player.GetComponent<playerManager>().resetHealth = 15f;
        player.GetComponent<playerManager>().health += 5f;
        yield return new WaitForSeconds(25f);
        player.GetComponent<playerManager>().resetHealth = 10f;
         player.GetComponent<playerManager>().health = oldHealth;
        GameObject.Destroy(gameObject);

    }
}
