using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsScript : MonoBehaviour
{
    public float DuracionParpadeo = 1.1f;
    public float IntervaloMinimo = 0.1f;
    public float IntervaloMax = 0.2f;

    private bool isBlinking = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isBlinking)
        {
            isBlinking = true;
            StartCoroutine(BlinkLamps());
        }
    }

    private System.Collections.IEnumerator BlinkLamps()
    {
        GameObject[] lamps = GameObject.FindGameObjectsWithTag("Lampara");
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

        float elapsedTime = 0f;
        while (elapsedTime < DuracionParpadeo)
        {
            foreach (GameObject lamp in lamps)
            {
                Light lightComponent = lamp.GetComponent<Light>();

                if (Random.value < 0.5f)
                {
                    lightComponent.enabled = !lightComponent.enabled;
                }
            }

            float interval = Random.Range(IntervaloMinimo, IntervaloMax);
            yield return new WaitForSeconds(interval);

            elapsedTime += interval;
        }

        foreach (GameObject lamp in lamps)
        {
            Destroy(lamp);
            
        }

        foreach (GameObject npc in npcs)
        {
            Destroy(npc);
        }

        isBlinking = false;
    }
}