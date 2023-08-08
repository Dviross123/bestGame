using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public slot slot;
    public inventory inventory;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;

    private int slotSelected;
    

   

    [SerializeField] private float scaleseSize;

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            
            slotSelected = 0;
            
            slot1.transform.localScale = new Vector3(scaleseSize, scaleseSize, scaleseSize);

            slot2.transform.localScale = new Vector3(1, 1, 1);
            slot3.transform.localScale = new Vector3(1, 1, 1);
            slot4.transform.localScale = new Vector3(1, 1, 1);

            Debug.Log("0");
        }

        if (Input.GetKeyDown("2"))
        {
            slotSelected = 1;

            slot2.transform.localScale = new Vector3(scaleseSize, scaleseSize, scaleseSize);

            slot1.transform.localScale = new Vector3(1, 1, 1);
            slot3.transform.localScale = new Vector3(1, 1, 1);
            slot4.transform.localScale = new Vector3(1, 1, 1);

            Debug.Log("1");
        }
        if (Input.GetKeyDown("3"))
        {
            slotSelected = 2;
            slot3.transform.localScale = new Vector3(scaleseSize, scaleseSize, scaleseSize);

            slot1.transform.localScale = new Vector3(1, 1, 1);
            slot2.transform.localScale = new Vector3(1, 1, 1);
            slot4.transform.localScale = new Vector3(1, 1, 1);

            Debug.Log("2");
        }
        if (Input.GetKeyDown("4"))
        {
            slotSelected = 3;
            slot4.transform.localScale = new Vector3(scaleseSize, scaleseSize, scaleseSize);

            slot1.transform.localScale = new Vector3(1, 1, 1);
            slot2.transform.localScale = new Vector3(1, 1, 1);
            slot3.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("3");
        }


        if (Input.GetButtonDown("dropItem")) 
        {
            Debug.Log("the slot is" + slotSelected);

            slot.dropItem(inventory.slots[slotSelected]);
        }

        if (Input.GetButtonDown("useItem"))
        {
            slot.useItem(inventory.slots[slotSelected]);
        }
    }
}
