using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{

    private GameObject player;
    public float shootingDis;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject bullet;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, player.GetComponent<Transform>().position)<shootingDis) 
        {
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else 
        {
            timeBtwShots -= Time.deltaTime;
        }
        }
        if(Mathf.Abs(player.GetComponent<Transform>().position.x - transform.position.x) >= 1)
        {
            if (player.GetComponent<Transform>().position.x < transform.position.x)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = -1f;
                transform.localScale = localScale;
            }
            else 
            {
                Vector3 localScale = transform.localScale;
                localScale.x = 1f;
                transform.localScale = localScale;
            }
        }
    }
}
