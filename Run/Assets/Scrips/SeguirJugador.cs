using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    //Llamamos al personaje
    public Transform Personaje;
    private ControladorJugador jugador;
    //Declaramos una distancia 
    public Vector3 Distancia;

    // Use this for initialization
    void Start()
    {
        jugador = FindObjectOfType(typeof(ControladorJugador)) as ControladorJugador;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = jugador.trans.position + Distancia;

    }
}
