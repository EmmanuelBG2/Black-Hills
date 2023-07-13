using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsScript : MonoBehaviour
{
    public float blinkDuration = 1.1f; // Duraci�n del parpadeo en segundos
    public float minInterval = 0.1f; // Intervalo m�nimo entre parpadeos en segundos
    public float maxInterval = 0.2f; // Intervalo m�ximo entre parpadeos en segundos

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

        // Parpadeo de las l�mparas
        float elapsedTime = 0f;
        while (elapsedTime < blinkDuration)
        {
            foreach (GameObject lamp in lamps)
            {
                Light lightComponent = lamp.GetComponent<Light>();

                if (Random.value < 0.5f)
                {
                    lightComponent.enabled = !lightComponent.enabled;
                }
            }

            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            elapsedTime += interval;
        }

        // Destruir las l�mparas
        foreach (GameObject lamp in lamps)
        {
            Destroy(lamp);
        }

        isBlinking = false;
    }
}