using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarEscena : MonoBehaviour
{
    public Transform cabinSpawnPoint;

    private void Start()
    {
        PlayerData.spawnPoint = cabinSpawnPoint;

        PlayerData.player = GameObject.FindGameObjectWithTag("Player");
    }
}
