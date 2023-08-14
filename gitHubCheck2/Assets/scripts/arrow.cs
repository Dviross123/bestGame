using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{



    public GameObject smallSlime;
    private GameObject player;

  

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("yes");
            player.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
