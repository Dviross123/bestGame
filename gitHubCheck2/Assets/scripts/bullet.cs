using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;

    private Transform playerTrans;
    private Vector2 target;
 
    public float bulletLifeTime;
    public GameObject player;
    private playerManager playerManager;


    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

        player= GameObject.FindGameObjectWithTag("Player");

        playerManager = player.GetComponent<playerManager>();

        target = new Vector2(playerTrans.position.x, playerTrans.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }



        bulletLifeTime -= Time.deltaTime;
        if (bulletLifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

   
}
