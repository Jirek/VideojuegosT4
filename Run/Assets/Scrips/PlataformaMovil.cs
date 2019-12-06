using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour {

    public Transform lugar;
    public float VelocidadPlataforma;

    private Vector3 start, end;

	void Start () {
        if (lugar != null)
        {
            lugar.parent = null;
            start = transform.position;
            end = lugar.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (lugar != null)
        {
            float Speed = VelocidadPlataforma * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,lugar.position,Speed);
        }

        if(transform.position == lugar.position)
        {
            lugar.position = (lugar.position == start) ? end : start;
        }
    }
}
