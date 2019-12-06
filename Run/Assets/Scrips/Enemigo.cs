using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    //Transform trans;
    public int VelocidadCorrer = 10;
    private ControladorJugador jugador;


    void Start()
    {
        //trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Estado", 1);
        rb.velocity = new Vector2(1 * VelocidadCorrer, rb.velocity.y);
        sr.flipX = true;
    }
  

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Personaje"))
        {
            anim.SetInteger("Estado", 2);
        }

        if (coll.gameObject.tag == "Enemigo")
        {
            Destroy(coll.gameObject);
        }
            if (coll.gameObject.tag == "Fuego")
        { 
                Destroy(coll.gameObject);
                //Sumar puntos
                jugador.puntaje = jugador.puntaje + 10;
                jugador.textoPuntaje.text = "Puntaje: " + jugador.puntaje.ToString();
                anim.SetBool("Morir", true);
                Invoke("DesaparecerEnemigo", 0.5f);
        }
           
        }
    void DesaparecerEnemigo()
    {
        Destroy(gameObject);
    }


}