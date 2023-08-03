using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarLlave : Interactable
{
    public GameObject ObjetoLlave;
    public GameObject ColliderPuerta;
    public GameObject PuertaCerrada;

    public override void Interact()
    {
        base.Interact();
        
        ColliderPuerta.gameObject.SetActive(true);
        PuertaCerrada.gameObject.SetActive(false);
        Destroy(ObjetoLlave);
    }
}
