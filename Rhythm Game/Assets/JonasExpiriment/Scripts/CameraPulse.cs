using UnityEngine;

public class CameraPulse : MonoBehaviour
{
    public float pulseDuration = 0.2f;
    public float pulseAmplitude = 1.2f;
    public Camera mainCamera;

    private float originalOrthoSize;
    private bool isPulsing = false;
    private float pulseEndTime;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        originalOrthoSize = mainCamera.orthographicSize;
    }

    void Update()
    {
        if (isPulsing)
        {
            if (Time.time < pulseEndTime)
            {
                // Calculate the new orthographic size for the camera based on a sine wave
                float t = (Time.time - (pulseEndTime - pulseDuration)) / pulseDuration;
                float newOrthoSize = originalOrthoSize + Mathf.Sin(t * Mathf.PI) * pulseAmplitude;

                // Apply the new orthographic size to the camera
                mainCamera.orthographicSize = newOrthoSize;
            }
            else
            {
                // End the pulse effect and reset the camera's orthographic size
                mainCamera.orthographicSize = originalOrthoSize;
                isPulsing = false;
            }
        }
    }

    public void TriggerPulse()
    {
        // Trigger a new pulse effect
        if (!isPulsing)
        {
            pulseEndTime = Time.time + pulseDuration;
            isPulsing = true;
            Debug.Log("did pulse");
        }
    }
}
