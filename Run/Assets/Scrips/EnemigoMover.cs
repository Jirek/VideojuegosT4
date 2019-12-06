using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMover : MonoBehaviour
{
    
    public Transform lugar;
    public float VelocidadEnemigo;
    SpriteRenderer sr;

    private Vector3 start, end;

    void Start()
    {
    
        if (lugar != null)
        {
            lugar.parent = null;
            start = transform.position;
            end = lugar.position;
        }
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (lugar != null)
        {
            float Speed = VelocidadEnemigo * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, lugar.position, Speed);

            //sr.flipX = !sr.flipX;
        }

        if (transform.position == lugar.position)
        {
            
            lugar.position = (lugar.position == start) ? end : start;
            sr.flipX = !sr.flipX;
        }
    }
}
