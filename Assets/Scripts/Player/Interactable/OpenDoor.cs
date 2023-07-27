using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : Interactable
{
    public string Intro;

    public override void Interact()
    {
        base.Interact();

        SceneManager.LoadScene(Intro);
    }
}
