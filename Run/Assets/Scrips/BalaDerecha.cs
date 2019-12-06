using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDerecha : MonoBehaviour
{
    public int velocidadBala = 10;
    private Vector2 direccionBala;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direccionBala = Vector2.right;
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direccionBala * velocidadBala;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Pared")
        {
            Destroy(gameObject);
        }
    }
}
