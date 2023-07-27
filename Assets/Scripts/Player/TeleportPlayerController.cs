using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerController : MonoBehaviour
{
    public Transform teleportPoint;


    private void TeleportPlayer()
    {
        if (teleportPoint != null)
        {
            Vector3 teleportPosition = teleportPoint.position;
            teleportPosition.y += 1.0f;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = teleportPosition;
        }
    }
}
