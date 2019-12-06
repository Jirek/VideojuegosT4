using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaIzquierda : MonoBehaviour
{
    public int velocidadBala = 10;
    private Vector2 direccionBala;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direccionBala = Vector2.left;
        Destroy(gameObject, 3);
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
