using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeScript : MonoBehaviour
{
    [SerializeField] private float damage = 2;
    [SerializeField] private Rigidbody2D rbE;
    [SerializeField] private Transform checkGroundEnemy;
    [SerializeField] private Transform checkWallEnemy;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private GameObject playerMovement;
    private bool canDamage = true;
    public float enemyWalkSpeed = 3f;
    public bool isJumping;
    private bool checkJump = false;
    [SerializeField] private bool ground;
    [SerializeField] private bool wall;

    private void Start()
    {
        playerMovement = GameObject.Find("Player");
    }
    private bool CanWalkForward()
    {
        return Physics2D.OverlapCircle(checkGroundEnemy.position, 0.2f, groundLayer);
    }
    private bool CanWalkForwardWall()
    {
        return Physics2D.OverlapCircle(checkWallEnemy.position, 0.2f, wallLayer);
    }

    // Update is called once per frame
    void Update()
    {
        ground = CanWalkForward();
        wall = CanWalkForwardWall();
        if (CanWalkForward() && checkJump)
        {
            isJumping = false;
        }

        if (checkSameX() && checkAbove() && !isJumping)
        {
            rbE.velocity = new Vector2(0f, 8f);
            isJumping = true;
            StartCoroutine(jumpWait());
        }
        else if (CanWalkForward() && !CanWalkForwardWall())
        {
            rbE.velocity = new Vector2(enemyWalkSpeed * transform.localScale.x, rbE.velocity.y);
        }
        else if (!isJumping)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            rbE.velocity = new Vector2(-2f * transform.localScale.x, rbE.velocity.y);
        }

        if (isJumping)
        {
            rbE.velocity = new Vector2(0f, rbE.velocity.y);
        }
    }

    bool checkSameX()
    {
        if(playerMovement.GetComponent<PlayerMovement>().transform.localPosition.x >= -8f + transform.localPosition.x && playerMovement.GetComponent<PlayerMovement>().transform.localPosition.x <= 8f + transform.localPosition.x)
        {
            return true;
        }
        return false;
    }
    bool checkAbove()
    {
        if(playerMovement.GetComponent<PlayerMovement>().transform.localPosition.y > transform.localPosition.y+2f)
        {
            return true;
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDamage)
        {
            playerMovement.GetComponent<playerManager>().takeDamage(damage);
            canDamage = false;
            StartCoroutine(canDamageReset());
        }
    }

    private IEnumerator jumpWait()
    {
        checkJump = false;
        yield return new WaitForSeconds(0.3f);
        checkJump = true;
    }

    private IEnumerator canDamageReset()
    {
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }
}
