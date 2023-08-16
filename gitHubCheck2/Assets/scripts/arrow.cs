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


    private IEnumerator tpDelay()
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.2f);

        Vector2 teleportPosition = transform.position;

        // Check if the arrow is hitting a collider or tilemap
        Collider2D hitCollider = Physics2D.OverlapCircle(teleportPosition, 0.4f); // Adjust the radius as needed

        if (hitCollider != null && hitCollider.CompareTag("ground")) // Adjust the tag as needed
        {
            teleportPosition = FindValidTeleportPosition(teleportPosition);
        }

        player.transform.position = teleportPosition;

        Destroy(gameObject);
    }

    private Vector2 FindValidTeleportPosition(Vector2 desiredPosition)
    {
        Vector2[] directions = new Vector2[]
        {
        Vector2.up,
        Vector2.right,
        Vector2.down,
        Vector2.left
        };

        foreach (Vector2 direction in directions)
        {
            Vector2 newPosition = desiredPosition + direction * 1f; // Adjust the offset as needed
            if (!HasCollision(newPosition))
            {
                return newPosition;
            }
        }

        return desiredPosition;
    }


    private bool HasCollision(Vector2 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, 0.1f); // Adjust the distance as needed
        return hit.collider != null && hit.collider.CompareTag("ground"); // Adjust the tag as needed
    }




    private bool hasHitWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rb.velocity.normalized, 0.5f);
        return hit.collider != null && hit.collider.CompareTag("ground"); // Adjust the tag as needed
    }
}
