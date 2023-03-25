using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;

    private Camera mainCamera;
    private Renderer objectRenderer;
    private bool isVisible = false;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null) print("ERROR: no audiosource found");
        if (audioClip == null) print("ERROR: no audioclip found");
        mainCamera = Camera.main;
        objectRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        isVisible = IsObjectVisible();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (true)
        {
            print(gameObject.name + " is visible");
            audioSource.PlayOneShot(audioClip);
        }
    }

    bool IsObjectVisible()
    {
        // Check if the object's renderer is enabled and if it's visible by any camera
        if (objectRenderer.isVisible)
        {
            // Convert the object's position from world space to viewport space
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

            // Check if the viewport position is within the camera's viewport (x and y between 0 and 1)
            bool isOnScreen = viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
                              viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
                              viewportPosition.z > 0; // Check if the object is in front of the camera

            return isOnScreen;
        }

        return false;
    }

}
