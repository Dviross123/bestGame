using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static bool isShoped = false;
    public bool cancelShop = false;
    public GameObject ShopTrigger;
    public GameObject Shop;
    public GameObject Slot1;
    public GameObject cross1;
    public GameObject Slot2;
    public GameObject cross2;
    public GameObject Slot3;
    public GameObject cross3;
    public GameObject Slot4;
    public GameObject cross4;

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
        ShopTrigger.SetActive(false);
        Slot1.GetComponent<RectTransform>().anchoredPosition = new Vector2(Slot1.GetComponent<RectTransform>().anchoredPosition.x, 600f);
        cross1.GetComponent<RectTransform>().anchoredPosition = new Vector2(cross1.GetComponent<RectTransform>().anchoredPosition.x, 756f);
        Slot2.GetComponent<RectTransform>().anchoredPosition = new Vector2(Slot2.GetComponent<RectTransform>().anchoredPosition.x, 600f);
        cross2.GetComponent<RectTransform>().anchoredPosition = new Vector2(cross2.GetComponent<RectTransform>().anchoredPosition.x, 756f);
        Slot3.GetComponent<RectTransform>().anchoredPosition = new Vector2(Slot3.GetComponent<RectTransform>().anchoredPosition.x, 600f);
        cross3.GetComponent<RectTransform>().anchoredPosition = new Vector2(cross3.GetComponent<RectTransform>().anchoredPosition.x, 756f);
        Slot4.GetComponent<RectTransform>().anchoredPosition = new Vector2(Slot4.GetComponent<RectTransform>().anchoredPosition.x, 600f);
        cross4.GetComponent<RectTransform>().anchoredPosition = new Vector2(cross4.GetComponent<RectTransform>().anchoredPosition.x, 756f);

        // Repeat for other slots and crosses
        Time.timeScale = 0f;
    }

    public void resume()
    {
        Time.timeScale = 1f;
        Slot1.GetComponent<RectTransform>().anchoredPosition = new Vector2(Slot1.GetComponent<RectTransform>().anchoredPosition.x, -1005.1f);
        cross1.GetComponent<RectTransform>().anchoredPosition = new Vector2(cross1.GetComponent<RectTransform>().anchoredPosition.x, -852f);
        Slot2.GetComponent<RectTransform>().anchoredPosition = new Vector2(Slot2.GetComponent<RectTransform>().anchoredPosition.x, -1005.1f);
        cross2.GetComponent<RectTransform>().anchoredPosition = new Vector2(cross2.GetComponent<RectTransform>().anchoredPosition.x, -852f);
        Slot3.GetComponent<RectTransform>().anchoredPosition = new Vector2(Slot3.GetComponent<RectTransform>().anchoredPosition.x, -1005.1f);
        cross3.GetComponent<RectTransform>().anchoredPosition = new Vector2(cross3.GetComponent<RectTransform>().anchoredPosition.x, -852f);
        Slot4.GetComponent<RectTransform>().anchoredPosition = new Vector2(Slot4.GetComponent<RectTransform>().anchoredPosition.x, -1005.1f);
        cross4.GetComponent<RectTransform>().anchoredPosition = new Vector2(cross4.GetComponent<RectTransform>().anchoredPosition.x, -852f);
        // Repeat for other slots and crosses
        Shop.SetActive(false);
        isShoped = false;
    }
    public IEnumerator noShop()
    {
        yield return new WaitForSeconds(0.1f);
        cancelShop = true;
    }
}
