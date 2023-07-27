using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvitarObjetosNPC : MonoBehaviour
{
    public float rangoDeteccion = 1.5f;
    public float distanciaMinima = 1f;
    public float velocidad = 2f;
    public LayerMask capaObstaculo;
    public LayerMask capaNPC;

    private void Update()
    {
        Vector3 direccionDeseada = transform.forward;
        bool hayObstaculo = Physics.Raycast(transform.position, direccionDeseada, rangoDeteccion, capaObstaculo);

        if (hayObstaculo)
        {
            Vector3 nuevaDireccion = GetNuevaDireccion();

            transform.position += nuevaDireccion * velocidad * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(nuevaDireccion);
        }
        else
        {
            transform.position += direccionDeseada * velocidad * Time.deltaTime;
        }
    }

    private Vector3 GetNuevaDireccion()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 direccionAleatoria = Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f) * transform.forward;
            direccionAleatoria.Normalize();

            if (!Physics.Raycast(transform.position, direccionAleatoria, distanciaMinima, capaObstaculo))
            {
                return direccionAleatoria;
            }
        }
        return -transform.forward;
    }
}

