using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static bool isShoped = false;
    public bool cancelShop = false;

    public GameObject canvasShopTrigger;
    public GameObject canvasShop;

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
            canvasShopTrigger.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvasShop.SetActive(true);
                isShoped = true;
                StopTime();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvasShopTrigger.SetActive(false);
    }


    void StopTime()
    {
        canvasShopTrigger.SetActive(false);
        

        // Repeat for other slots and crosses
        Time.timeScale = 0f;
    }

    public void resume()
    {
        Time.timeScale = 1f;
        
        // Repeat for other slots and crosses
        canvasShop.SetActive(false);
        isShoped = false;
    }
    public IEnumerator noShop()
    {
        yield return new WaitForSeconds(0.1f);
        cancelShop = true;
    }
}
