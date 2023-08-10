using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderGenerat : MonoBehaviour
{
    private GameObject player;
    private int damage = 2;
    public GameObject boulder;
    private bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
        StartCoroutine(boulderGen());
        }
    }
    public IEnumerator boulderGen()
    {
        canSpawn = false;
        Instantiate(boulder, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        canSpawn = true;
    }
}
