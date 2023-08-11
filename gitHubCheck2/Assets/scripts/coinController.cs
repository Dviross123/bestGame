using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float upPower = 4;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(rb.velocity.x, upPower + rb.velocity.y / 4);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
