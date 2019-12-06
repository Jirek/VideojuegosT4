using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour {
    bool puede = false;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("CabezaEnemigo"))
        {
            Debug.Log("Puede Destruir Enemigo");
            Destroy(c.gameObject);
            puede = true;
        }
        if (c.gameObject.CompareTag("Enemigo") && puede==true)
        {
            Destroy(c.gameObject);
        }
    }
}
