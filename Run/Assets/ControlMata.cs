using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMata : MonoBehaviour
{
    Rigidbody2D rb;
   // public float velocidad=3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(4,rb.velocity.y);
    }
}
