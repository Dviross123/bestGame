using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public bool isShoped = false;
    public bool cancelShop = false;
    public GameObject ShopTrigger;
    public GameObject Shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isShoped)
            {
                resume();
                StartCoroutine(noShop());
                cancelShop = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShopTrigger.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Shop.SetActive(true);
                isShoped = true;
                StopTime();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ShopTrigger.SetActive(false);
    }


    void StopTime()
    {
        ShopTrigger.SetActive(false);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        Time.timeScale = 1f;
        Shop.SetActive(false);
        isShoped = false;
    }
    public IEnumerator noShop()
    {
        yield return new WaitForSeconds(0.1f);
        cancelShop = true;
    }
}
