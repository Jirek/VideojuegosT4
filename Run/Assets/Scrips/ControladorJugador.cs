using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorJugador : MonoBehaviour
{

    public int VelocidadCorrer = 5;
    public int FuerzaSalto = 10;
    public int NumeroSaltos;

    public bool grounded;
    public bool EsqueletonAtaca;
    public bool EsqueletonCamina;

    public Transform trans;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;


    public Transform posicionBalaDerecha;
    public GameObject BalaDerecha;
    public Transform posicionBalaIzquierda;
    public GameObject BalaIzquierda;
    public int direccion = 0;


    bool HongoFuego = false;
    bool CambiarEscena = false;
    bool CambiarEscena3 = false;
    bool PuedeSubir = false;
    bool ChocaFin = false;



    public int salud;
    public Text textoSalud;

    public int puntaje;
    public Text textoPuntaje;

    public GameObject sonidoMundo;
    public GameObject moneda;
    public GameObject PierdeVida;

    

    void Start()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        salud = 5;
        Instantiate(sonidoMundo);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Caminar", true);
            rb.velocity = new Vector2(1 * VelocidadCorrer, rb.velocity.y);
            direccion = 0;
            sr.flipX = false;
            

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("Caminar", false);
            rb.velocity = new Vector2(0 * VelocidadCorrer, rb.velocity.y);

        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {

            anim.SetBool("Caminar", true);
            rb.velocity = new Vector2(-1 * VelocidadCorrer, rb.velocity.y);
            direccion = 1;
            sr.flipX = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("Caminar", false);
            rb.velocity = new Vector2(0 * VelocidadCorrer, rb.velocity.y);


        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && NumeroSaltos < 2)
        {
            anim.SetBool("Saltar", true);
            rb.velocity = new Vector2(rb.velocity.x * 1, FuerzaSalto);
            NumeroSaltos++;
        }

        if (HongoFuego == true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                anim.SetBool("Atacar", true);
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                Invoke("DejarDeDisparar", 0.3f);
            }
        }


        if (CambiarEscena == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SceneManager.LoadScene("Nivel2");
            }
        }

        if (CambiarEscena3 == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SceneManager.LoadScene("Nivel3");
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) && PuedeSubir)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Piso")
        {
            NumeroSaltos = 0;
            anim.SetBool("Saltar", false);
        }
        if (coll.gameObject.tag == "Vacio")
        {
            anim.SetBool("Morir", true);
            salud = 0;
            Invoke("DesaparecerPersonaje", 0.5f);
        }

        if (coll.gameObject.tag == "HongoFuego")
        {
            Destroy(coll.gameObject);
            HongoFuego = true;
            Debug.Log("Puede Disparar");
        }

        if (coll.gameObject.tag == "Enemigo")
        {
            //Destroy(coll.gameObject);
            Instantiate(PierdeVida);
            anim.SetBool("PerderVida", true);
            Invoke("Reponerse", 0.9f);
            salud = salud - 1;
            textoSalud.text = "Vida: " + salud;
            if (salud == 0)
            {
                anim.SetBool("Morir", true);
                //Invoke("DesaparecerPersonaje", 0.5f);
                JuegoPerdido();
            }
        }
        if (coll.gameObject.CompareTag("Agua"))
        {
            //Destroy(gameObject);
            //Invoke("Reponerse", 0.9f);
            ReiniciarEscena();


        }

           if (coll.gameObject.CompareTag("terceronivel"))
        {
            //Destroy(gameObject);
            //Invoke("Reponerse", 0.9f);
            ReiniciarEscena3();


        }


        if (coll.gameObject.tag == "GameOver")
        {
            SceneManager.LoadScene("FinJuego");
        }


    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("CambiaraEscena"))
        {
            CambiarEscena = true;
            Debug.Log("Puede Cambiar");
        }
        if (c.gameObject.CompareTag("CambiarEscena3"))
        {
            CambiarEscena3 = true;
            Debug.Log("Puede Cambiar3");
        }


        if (c.gameObject.tag == "Moneda")
        {
            Instantiate(moneda);
            Destroy(c.gameObject);
            puntaje = puntaje + 1;
            textoPuntaje.text = "Puntaje: " + puntaje.ToString();
        }

        if (c.gameObject.tag == "Destruir")
        {
            SceneManager.LoadScene("Nivel3");
        }

        if (c.gameObject.tag == "escalera")
        {
            Debug.Log("choca con la escalera");
        }





        if (c.gameObject.tag == "Area")
        {
            Debug.Log("Esta en el area de ataque de esqueleton");
            EsqueletonCamina=true;
        }

        if (c.gameObject.tag == "Espada")
        {
            Debug.Log("Esta siendo atacado por esqueleton");
            EsqueletonAtaca=true;
        }

    }

    void DejarDeDisparar()
    {
        anim.SetBool("Atacar", false);
        if (direccion == 0)
            Instantiate(BalaDerecha, posicionBalaDerecha.position, Quaternion.identity);
        if (direccion == 1)
            Instantiate(BalaIzquierda, posicionBalaIzquierda.position, Quaternion.identity);

    }

    void Reponerse()
    {
        anim.SetBool("PerderVida", false);
 
    }

    void DesaparecerPersonaje()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Nivel1");
    }
    void ReiniciarEscena()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene("Nivel1");
    }


 void DesaparecerPersonaje2()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Nivel2");
    }
    void ReiniciarEscena2()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene("Nivel2");
    }


void DesaparecerPersonaje3()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Nivel3");
    }
    void ReiniciarEscena3()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene("Nivel3");
    }

    void JuegoPerdido()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene("JuegoPerdido");
    }


}



