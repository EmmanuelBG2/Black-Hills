using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource audioSourcePrefab1;
    public AudioSource audioSourcePrefab2;

    bool playSonido = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playSonido)
            {
                playSonido=true;
                StartCoroutine(PlayAudioSources());
                Destroy(gameObject, 4f);
            }
        }
    }

    private IEnumerator PlayAudioSources()
    {
        AudioSource audioSource1 = Instantiate(audioSourcePrefab1, transform.position, Quaternion.identity);
        audioSource1.Play();

        yield return new WaitForSeconds(1f);

        AudioSource audioSource2 = Instantiate(audioSourcePrefab2, transform.position, Quaternion.identity);
        audioSource2.Play();

        Destroy(audioSource1.gameObject, audioSource1.clip.length);
        Destroy(audioSource2.gameObject, audioSource2.clip.length);
    }
}
