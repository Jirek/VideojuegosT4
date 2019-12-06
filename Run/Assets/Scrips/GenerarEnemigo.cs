using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigo : MonoBehaviour
{

    public GameObject GenerarEnemi;
    public float tiempoPaGenerar = 4f;
    // Use this for initialization
    void Start()
    {
        //CrearEnemigo();
        InvokeRepeating("CrearEnemigo", 0f, tiempoPaGenerar);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CrearEnemigo()
    {
        Instantiate(GenerarEnemi, transform.position, Quaternion.identity);
    }
}