using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purchase : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float price = 1;

    private inventory inventory;
    public GameObject itemButton;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Buy()
    {
        if(player.GetComponent<playerManager>().money >= price)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    player.GetComponent<playerManager>().money -= price;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    break;
                }
            }
        }
    }
}
