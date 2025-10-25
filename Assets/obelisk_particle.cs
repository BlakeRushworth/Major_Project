using UnityEngine;

public class obelisk_particle : MonoBehaviour
{
    /*  THIS CIRCLE AROUND INFRONT AND BEHIND INSTEAD OF ALL AROUND
    public Transform centerPoint; // The object around which to rotate
    public float radius = 5f;
    public float speed = 1f;
    private float angle = 0f;

    void Start()
    {
    }

    void Update()
    {
        // Calculate the new angle based on speed and time
        angle += speed * Time.deltaTime;

        // Calculate the new X and Z positions using Sin and Cos
        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float z = centerPoint.position.z + radius * Mathf.Sin(angle);

        // Maintain the Y position if you're working in 2D or want a flat circle
        // Otherwise, you might adjust Y as well for a 3D circular path
        float y = centerPoint.position.y;

        // Update the object's position
        transform.position = new Vector3(x, y, z);


    }
    */

    public Transform centerPoint; // The center of the circle
    public float radius = 5f;    // The radius of the circle
    public float speed = 1f;     // The speed of rotation
    private float angle = 0f;    // Current angle in radians

    private void Start()
    {
        centerPoint = GetComponentInParent<Rigidbody2D>().transform;
    }

    void Update()
    {
        // Increment the angle based on speed and time
        angle += speed * Time.deltaTime;

        // Calculate the X and Z coordinates using sine and cosine
        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float y = centerPoint.position.z + radius * Mathf.Sin(angle);

        // Set the object's position, keeping the Y-coordinate constant for top-down view
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
