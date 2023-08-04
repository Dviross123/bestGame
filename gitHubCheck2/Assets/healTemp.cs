using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healTemp : MonoBehaviour
{
    private GameObject player;
    public float timeOfHeal;
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
        player.GetComponent<playerManager>().health = player.GetComponent<playerManager>().resetHealth + 5;
        yield return new WaitForSeconds(timeOfHeal);
        player.GetComponent<playerManager>().health = player.GetComponent<playerManager>().resetHealth;
        GameObject.Destroy(gameObject);

    }
}
