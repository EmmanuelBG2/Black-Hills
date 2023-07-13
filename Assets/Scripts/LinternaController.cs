using UnityEngine;

public class LinternaController : MonoBehaviour
{
    private Light flashlight;

    private void Start()
    {
        flashlight = GameObject.Find("Linterna").GetComponent<Light>();
        flashlight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}