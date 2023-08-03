using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorClosed : Interactable
{
    public AudioSource SoundClosed;
    private bool isSoundPlaying = false;

    public override void Interact()
    {
        base.Interact();

        if (!isSoundPlaying)
        {
            isSoundPlaying = true;
            AudioSource sound = Instantiate(SoundClosed, transform.position, Quaternion.identity);
            sound.Play();
            Destroy(sound.gameObject, 2F);
            StartCoroutine(ResetSoundStatus());
        }
    }

    private IEnumerator ResetSoundStatus()
    {
        yield return new WaitForSeconds(1F);
        isSoundPlaying = false;
    }
}
