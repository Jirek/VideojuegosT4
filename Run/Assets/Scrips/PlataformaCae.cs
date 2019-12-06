using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCae : MonoBehaviour {
    public float tiempoCaida = 1f;
    Rigidbody2D rb;
    PolygonCollider2D pc;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje"))
        {
            Invoke("Caer",tiempoCaida);
        }
        if (collision.gameObject.tag == "Agua")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Piso")
        {
            Destroy(gameObject);
        }
    }
    void Caer()
    {
        rb.isKinematic = false;
      //  pc.isTrigger = true;
    }
}
