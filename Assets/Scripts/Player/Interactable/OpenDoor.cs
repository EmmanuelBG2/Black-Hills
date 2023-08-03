using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : Interactable
{
    public string Escena;
    bool tieneLlave = false;

    public AudioSource soundOpen;

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(LoadSceneAndSpawnPlayer());
    }

    IEnumerator LoadSceneAndSpawnPlayer()
    {
        AudioSource audioSource1 = Instantiate(soundOpen, transform.position, Quaternion.identity);
        audioSource1.Play();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(Escena);

        yield return null;
        if (PlayerData.spawnPoint != null && PlayerData.player != null)
        {
            PlayerData.player.transform.position = PlayerData.spawnPoint.position;
        }
    }
}
