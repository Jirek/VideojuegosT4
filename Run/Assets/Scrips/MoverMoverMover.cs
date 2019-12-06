using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverMoverMover : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    bool ChocaPersonaje = false;
    float vel = 4f;
    private ControladorJugador jugador;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
            anim.SetInteger("Estado", 1);
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            //sr.flipX = false;
        

        if (ChocaPersonaje == true)
        {
            anim.SetInteger("Estado", 2);
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            sr.flipX = false;
        }


    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Pared")
        {
            sr.flipX = !sr.flipX;
            vel = vel * 1;
        }
        if (c.gameObject.tag == "Fuego")
        {
            Destroy(this.gameObject);
            Debug.Log("Choca con fuego");
            //Sumar puntos
            jugador.puntaje = jugador.puntaje + 10;
            jugador.textoPuntaje.text = "Puntaje: " + jugador.puntaje.ToString();
            anim.SetBool("Morir", true);
            Invoke("DesaparecerEnemigo", 0.5f);
            anim.SetInteger("Estado", 3);
        }
       
    }
    //void DesaparecerEnemigo()
   // {
   //     Destroy(gameObject);
  //  }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Personaje"))
        {
            ChocaPersonaje = true;
            
        }
        if (coll.gameObject.CompareTag("PAREDBU"))
        {
            sr.flipX = !sr.flipX;
            vel = vel * -1;

        }

    }
}
