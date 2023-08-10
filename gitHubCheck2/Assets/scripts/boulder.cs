using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(destroy());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            player.GetComponent<playerManager>().takeDamage(damage);
        }
    }
    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
       
    }
}
