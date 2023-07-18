using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningPosition : MonoBehaviour
{
    public swordAttack swordAttack;
    public GameObject gameCamera;
    public CameraFollow cameraFollow;

    void Update()
    {
        if (swordAttack.isAttacking && swordAttack.attackNum == 3)
        {
            cameraFollow.enabled = false;
            float randomX = Random.Range(gameCamera.transform.position.x - 10f, gameCamera.transform.position.x + 10f);
            Vector3 newPosition = transform.position;
            newPosition.x = randomX;
            StartCoroutine(wait());
            transform.position = newPosition;
        }
        else 
        {
            cameraFollow.enabled = true;
        }
    }
    private IEnumerator wait() 
    {
        yield return new WaitForSeconds(4f);
    }
}
