using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{



    public GameObject smallSlime;
    private GameObject player;
    private bool canTeleport = true;
    private Vector2 temp;
    public Rigidbody2D rb;
    bool hasHit;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(teleport());

    }
    private void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("yes");
            if (canTeleport)
            {
                StartCoroutine(tpDelay());
            }
        }
    }
    private IEnumerator teleport()
    {
        yield return new WaitForSeconds(1.5f);
        player.transform.position = transform.position;
        canTeleport = false;
    }
    private IEnumerator tpDelay()
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.2f);
        player.transform.position = transform.position;

        Destroy(gameObject);
    }
}