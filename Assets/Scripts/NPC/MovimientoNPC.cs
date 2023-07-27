using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNPC : MonoBehaviour
{

    public float rangoAlerta = 5F;
    public LayerMask capaDelJugador;
    
    public Transform jugador;

    public float velocidad = 2F;

    public float minRotationTime = 20f;
    public float maxRotationTime = 25f;
    public float rotationSpeed = 3f;

    bool estarAlerta;
    void Start()
    {

    }
   
    void Update()
    {
        
        estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capaDelJugador);
        

        if (estarAlerta != true)
        {
            //transform.LookAt(jugador);
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
    }

}
