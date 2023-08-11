using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinsUpdater : MonoBehaviour
{

    private GameObject player;
    [SerializeField] private TextMeshProUGUI coins;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }
    

    // Update is called once per frame
    void Update()
    {
        coins.text = "coins:" + player.GetComponent<playerManager>().money;
    }
}
