using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbE;
    [SerializeField] private Transform checkGroundEnemy;
    [SerializeField] private Transform checkWallEnemy;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    public PlayerMovement playerMovement;
    public float enemyWalkSpeed = 3f;
    private bool isJumping;

    private void Start()
    {
        
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
        if (CanWalkForward())
            isJumping = false;
        if (isJumping)
            return;
        if ((checkSameX() && checkAbove() && !isJumping) || !checkAbove())
        {
            isJumping = true;
            rbE.velocity = new Vector2(0f, 8f);
        }
        else if (CanWalkForward() && !CanWalkForwardWall())
        {
            rbE.velocity = new Vector2(enemyWalkSpeed * transform.localScale.x, rbE.velocity.y);
        }
        else
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            rbE.velocity = new Vector2(-2f * transform.localScale.x, rbE.velocity.y);
        }
    }

    bool checkSameX()
    {
        if(playerMovement.transform.localPosition.x >= -4f + transform.localPosition.x && playerMovement.transform.localPosition.x <= 4f + transform.localPosition.x)
        {
            return true;
        }
        return false;
    }
    bool checkAbove()
    {
        if(playerMovement.transform.localPosition.y > transform.localPosition.y+2f)
        {
            return true;
        }
        return false;
    }

}
