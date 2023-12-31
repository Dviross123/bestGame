using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Events;

public class enemyAi : MonoBehaviour
{

    private bool playerCanDamage = true;
    private bool canDamage = true;
    private bool hit;
    public float damage = 1;
    public float maxHealth = 8;
    public float health;
    [SerializeField] private float knockbackPower = 12;
    private GameObject player;
    private GameObject swordAttack;
    private GameObject bowAttack;
    public GameObject coin;

    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    public Transform enemyGfx;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        player = GameObject.Find("Player");
        swordAttack = GameObject.Find("sword");
        bowAttack = GameObject.Find("bow");


        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }
    void UpdatePath()
    {
        if (seeker.IsDone() || !hit)
            seeker.StartPath(rb.position, player.GetComponent<Transform>().position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(coin, new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y), Quaternion.identity);
            Instantiate(coin, new Vector2(gameObject.transform.position.x  + 1, gameObject.transform.position.y), Quaternion.identity);
            Instantiate(coin, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
        }

        if (path == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            if (bowAttack.GetComponent<bowAttack>().isMaxForce)
            {
                health -= 2;
            }
            else
            {
                health--;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDamage)
        {
            player.GetComponent<playerManager>().takeDamage(damage);
            canDamage = false;
            StartCoroutine(damageWait());
        }
    }
   private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword") && swordAttack.GetComponent<swordAttack>().isKilling && swordAttack.GetComponent<swordAttack>().attackNum == 3 && playerCanDamage)
        {
            health -= 2;
            playerCanDamage = false;
            if (player.GetComponent<PlayerMovement>().isFacingRight)
            {

                rb.velocity = new Vector2(knockbackPower * 3, 0f);
            }
            else
            {
                rb.velocity = new Vector2(knockbackPower * -3, 0f);
            }
            StartCoroutine(HitByPlayer());
            StartCoroutine(playerDamageWait());
            
        }
        if (collision.gameObject.CompareTag("sword") && swordAttack.GetComponent<swordAttack>().isKilling && (swordAttack.GetComponent<swordAttack>().attackNum == 1 || swordAttack.GetComponent<swordAttack>().attackNum == 2) && playerCanDamage)
        {
            health--;
            playerCanDamage = false;
            if (player.GetComponent<PlayerMovement>().isFacingRight)
            {

                rb.velocity = new Vector2(knockbackPower * 2, 0f);
            }
            else
            {
                rb.velocity = new Vector2(knockbackPower * -2, 0f);
            }
            StartCoroutine(HitByPlayer());
            reachedEndOfPath = false;
            StartCoroutine(playerDamageWait());
        }
    }
    private IEnumerator HitByPlayer()
    {
        hit = true;
        yield return new WaitForSeconds(1f);
        hit = false;
    }
    private IEnumerator playerDamageWait()
    {
        yield return new WaitForSeconds(0.6f);
        playerCanDamage = true;
    }
    private IEnumerator damageWait()
    {
        yield return new WaitForSeconds(0.6f);
        canDamage = true;
    }


    
}