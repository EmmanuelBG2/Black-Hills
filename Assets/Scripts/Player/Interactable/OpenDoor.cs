using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : Interactable
{
    public string Escena;
    bool tieneLlave = false;

    public override void Interact()
    {

        base.Interact();

        SceneManager.LoadScene(Escena);
    }
}
