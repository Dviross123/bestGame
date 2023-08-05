using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killStrrongRobot : MonoBehaviour
{
    //floats
    public float robotHealth;
    public float maxRobotHealth;
    public bool canDamage = true;

    //scripts
    private GameObject swordAttack;
    private GameObject bowAttack;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        robotHealth = maxRobotHealth;
        player = GameObject.Find("Player");
        swordAttack = GameObject.Find("sword");
        bowAttack = GameObject.Find("bow");
    }

    // Update is called once per frame
    void Update()
    {
        if (robotHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            Debug.Log("arrow");
            robotHealth--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("arrow");
        if (collision.gameObject.CompareTag("arrow"))
        {
            if (bowAttack.GetComponent<bowAttack>().isMaxForce)
            {
                Debug.Log("big pew");
                robotHealth -= 2f;
            }
            else
            {
                Debug.Log("little pew");
                robotHealth--;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword") && swordAttack.GetComponent<swordAttack>().isKilling && swordAttack.GetComponent<swordAttack>().attackNum == 3 && canDamage)
        {
            Debug.Log("swordBig");
            robotHealth -= 2;
            canDamage = false;
        }
        else if (collision.gameObject.CompareTag("sword") && swordAttack.GetComponent<swordAttack>().isKilling && canDamage)
        {
            Debug.Log("sword");
            robotHealth--;
            canDamage = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canDamage = true;
    }
}