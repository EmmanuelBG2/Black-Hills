using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    private Transform camara;

    public float rayDistance;

    void Start()
    {
        camara = transform.Find("Camera");
    }

    void Update()
    {
        Debug.DrawRay(camara.position, camara.forward * rayDistance, Color.red);

        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;


            if (Physics.Raycast(camara.position, camara.forward, out hit, rayDistance, LayerMask.GetMask("Interactable")))
            {
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }


}
