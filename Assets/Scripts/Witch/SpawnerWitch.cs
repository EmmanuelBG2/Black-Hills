using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWitch : MonoBehaviour
{
    public Transform spawnWitch;
    public GameObject spawnPrefab;
    public float spawnTime = 0.3f;
    private float currentTime = 0f;

    [SerializeField]
    Vector3 WitchRotation;

    void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && currentTime >= spawnTime)
        {
            Instantiate(spawnPrefab, spawnWitch.position, Quaternion.Euler(WitchRotation));
            currentTime = 0f;
        }
    }
}
