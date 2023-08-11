using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class killSlime : MonoBehaviour
{
    private float damage = 1;
    public bool slimeDeath;
    public bool smallSlimeExplode;
    private GameObject sword;
    private new GameObject camera;
    private Animator animator;
    private Animator slimeAnimator;
    private BoxCollider2D box;
    private GameObject player;
    private bool killSmallSlime;
    public GameObject coin;

    private void Start()
    {
        sword = GameObject.Find("sword");
        camera = GameObject.Find("MainCamera");
        animator = camera.GetComponent<Animator>();
        slimeAnimator = gameObject.GetComponent<Animator>();
        box = gameObject.GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(Die());
            animator.SetBool("slimeDie", true);
            StartCoroutine(waitForShakeEnd());
            slimeAnimator.SetBool("isDead", true);
            Instantiate(coin, gameObject.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Player"))
        {      
            if (player.GetComponent<playerManager>().isKillingSlimeFF)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                killSmallSlime = true;
                StartCoroutine(KillWait(collision));
                slimeAnimator.SetBool("isDead", true);
            }

        }

    }
    public IEnumerator KillWait(Collision2D collision)
    {

        yield return new WaitForSeconds(.7f);

        Destroy(gameObject);
        killSmallSlime = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword") && sword != null && sword.GetComponent<swordAttack>().isKilling)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(Die());
            animator.SetBool("slimeDie", true);
            StartCoroutine(waitForShakeEnd());
            slimeAnimator.SetBool("isDead", true);
            Instantiate(coin, gameObject.transform.position, Quaternion.identity);
        }
       

    }

    private IEnumerator Die()
    {
        smallSlimeExplode = true;
        slimeDeath = true;
        box.enabled = false;
        yield return new WaitForSeconds(0.8f);
        slimeDeath = false;
        slimeAnimator.SetBool("isDead", false);
        Destroy(gameObject);
    }
    private IEnumerator waitForShakeEnd()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("slimeDie", false);
    }

   

}
