using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo : MonoBehaviour
{
    private ControladorJugador player;
    private Rigidbody2D rb;
    void Start()
    {
        player = GetComponentInParent<ControladorJugador>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataforma")
        {
            rb.velocity = new Vector3(0f,0f,0f);
            player.transform.parent = col.transform;
            player.grounded = true;
        }
        if (col.gameObject.tag == "Piso")
        {
            player.transform.parent = col.transform;
            player.grounded = true;
        }

    }
    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "Piso"){
            player.grounded = true;
        }
        if(col.gameObject.tag == "Plataforma"){
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Piso")
        {
            player.grounded = false;
        }
        if (col.gameObject.tag == "Plataforma")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }

}
