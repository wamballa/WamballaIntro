using System;
using System.Collections.Generic;
using UnityEngine;

public class LogoSpawner : MonoBehaviour
{
    public int targetPixelSize = 1;
    public List<Sprite> sprites = new List<Sprite>();
    public PhysicsMaterial2D myPhysicsMaterial;
    public float speed = 7f;
    public float angle = 10f;
    public bool triggerAutomatically = false;
    public AudioClip audioClip;

    private Rigidbody2D rb;

    public LayerMask targetLayerMask;

    void Start()
    {
        ScaleSpritesToPixelSize();
        if (triggerAutomatically) SpawnLogos();
    }

    public void SpawnLogos()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(true);
            ApplyRandomUpwardVelocity(t);
        }
    }

    void ScaleSpritesToPixelSize()
    {
        // Get the single layer index from the LayerMask
        int targetLayer = Mathf.RoundToInt(Mathf.Log(targetLayerMask.value, 2));

        // Iterate through all Sprites in the list
        foreach (Sprite sprite in sprites)
        {
            // Create a new GameObject and add a SpriteRenderer
            GameObject spriteObject = new GameObject(sprite.name);
            SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;

            float pixelsPerUnit = sprite.pixelsPerUnit;
            float originalWidth = sprite.rect.width;

            // Calculate the scaling factor based on the desired pixel size
            float scale = (targetPixelSize / originalWidth) * pixelsPerUnit;

            // Apply scaling to the GameObject
            spriteObject.transform.localScale = new Vector3(scale, scale, 1f);

            // Make the new GameObject a child of the current GameObject (optional)
            spriteObject.transform.SetParent(transform);

            // Set the localPosition to zero (center of the parent)
            spriteObject.transform.localPosition = Vector3.zero;

            // Set the layer of the GameObject
            spriteObject.layer = targetLayer;

            // Add audiosource
            spriteObject.AddComponent<AudioSource>();

            // Add impact sounds script
            spriteObject.AddComponent<ImpactSounds>();

            // Add clip to this script
            spriteObject.GetComponent<ImpactSounds>().audioClip = audioClip;

            // Add physics
            AddPhysicsComponents(spriteObject);

            // Hide gameObject if not auto
            if (!triggerAutomatically) spriteObject.SetActive(false);
        }
    }

    private void AddPhysicsComponents(GameObject spriteObject)
    {
        rb = spriteObject.AddComponent<Rigidbody2D>();
        //rb = GetComponent<Rigidbody2D>();

        // Add a BoxCollider2D to the new GameObject
        BoxCollider2D boxCollider2D = spriteObject.AddComponent<BoxCollider2D>();
        // Assign the Physics Material to the BoxCollider2D
        boxCollider2D.sharedMaterial = myPhysicsMaterial;
        // Get sprite renderer to scale the boxcollider
        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        // Scale the BoxCollider2D to match the size of the SpriteRenderer's sprite
        boxCollider2D.size = spriteRenderer.sprite.bounds.size;
    }

    void ApplyRandomUpwardVelocity(Transform _transform)
    {
        Rigidbody2D rb = _transform.GetComponent<Rigidbody2D>();

        float randomAngle = UnityEngine.Random.Range(-angle, angle);

        // Convert the random angle to radians
        float angleInRadians = randomAngle * Mathf.Deg2Rad;

        // Calculate the x and y components of the vector based on the angle and speed
        float x = Mathf.Sin(angleInRadians) * speed;
        float y = Mathf.Cos(angleInRadians) * speed;

        Vector2 upwardVelocity = new Vector2(x, y);
        rb.velocity = upwardVelocity;
    }
}
