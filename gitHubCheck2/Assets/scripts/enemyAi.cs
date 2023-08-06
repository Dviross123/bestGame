using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyAi : MonoBehaviour
{

    public Transform target;

    public float damage = 1;
    public float maxHealth = 8;
    public float health;
    private GameObject player;
    private GameObject swordAttack;
    private GameObject bowAttack;


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
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
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
            Destroy(gameObject);

        if(path == null)
            return;

        if(currentWayPoint >= path.vectorPath.Count)
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

        if(distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<playerManager>().takeDamage(damage);
        }
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword") && swordAttack.GetComponent<swordAttack>().isKilling && swordAttack.GetComponent<swordAttack>().attackNum == 3 && canDamage)
        {
            health -= 2;
            canDamage = false;
            StartCoroutine(DamageWait());
        }
        if (collision.gameObject.CompareTag("sword") && swordAttack.GetComponent<swordAttack>().isKilling && (swordAttack.GetComponent<swordAttack>().attackNum == 1 ||swordAttack.GetComponent<swordAttack>().attackNum == 2) && canDamage )
        {
            health--;
            canDamage = false;
            StartCoroutine(DamageWait());
        }
    }
    private IEnumerator DamageWait()
    {
        yield return new WaitForSeconds(0.3f);
        canDamage = true;
    }
}
