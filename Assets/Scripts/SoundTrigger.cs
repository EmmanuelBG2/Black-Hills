using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource audioSourcePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource audioSource = Instantiate(audioSourcePrefab, transform.position, Quaternion.identity);
            audioSource.Play();
            Destroy(gameObject, 4f);
        }
    }

}
