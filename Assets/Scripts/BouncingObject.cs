using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 3.0f;
    private float angle = 20f;

    public PhysicsMaterial2D myPhysicsMaterial;

    private void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        //rb = GetComponent<Rigidbody2D>();

        // Add a BoxCollider2D to the new GameObject
        BoxCollider2D boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        // Assign the Physics Material to the BoxCollider2D
        boxCollider2D.sharedMaterial = myPhysicsMaterial;
        // Get sprite renderer to scale the boxcollider
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // Scale the BoxCollider2D to match the size of the SpriteRenderer's sprite
        boxCollider2D.size = spriteRenderer.sprite.bounds.size;
    }

    void Start()
    {
        ApplyRandomUpwardVelocity();
    }


    void ApplyRandomUpwardVelocity()
    {
        float randomAngle = Random.Range(-angle, angle);

        // Convert the random angle to radians
        float angleInRadians = randomAngle * Mathf.Deg2Rad;

        // Calculate the x and y components of the vector based on the angle and speed
        float x = Mathf.Sin(angleInRadians) * speed;
        float y = Mathf.Cos(angleInRadians) * speed;

        Vector2 upwardVelocity = new Vector2(x, y);
        rb.velocity = upwardVelocity;
    }
}
