using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotPointFlip : MonoBehaviour
{
    public PlayerMovement player;

    public void flip()
    {
        Vector3 localPosition = transform.localPosition;
        localPosition.x *= -1f;
        transform.localPosition = localPosition;

    }
}
