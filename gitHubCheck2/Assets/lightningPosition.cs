using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningPosition : MonoBehaviour
{
    public swordAttack swordAttack;
    public GameObject gameCamera;
    public CameraFollow cameraFollow;
    Vector3 newPosition;

    void Update()
    {
        if (swordAttack.isAttacking && swordAttack.attackNum == 3)
        {
            StartCoroutine(wait());
        }


    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        cameraFollow.enabled = false;
        float randomX = Random.Range(gameCamera.transform.position.x - 5.5f, gameCamera.transform.position.x + 5.5f);
        float Yposition = gameCamera.transform.position.y + 7f;
        newPosition.x = randomX;
        newPosition.y = Yposition;
        transform.position = newPosition;
    }

}