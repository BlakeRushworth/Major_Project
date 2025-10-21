using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player_Arrow : MonoBehaviour
{
    Rigidbody2D player;

    public Rigidbody2D RB;
    public float speed = 10f;
    public float rotationSpeed = 10f;

    private Camera mainCamera;
    private Vector3 mouse_pos;

    private Vector2 direction;

    private bool homing = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //mouse_pos = mainCamera.ScreenToViewportPoint(Input.mousePosition);


        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Ensure the z-coordinate matches the firePoint's z for 2D accuracy
        mousePos.z = player.transform.position.z;

        // Calculate direction vector from firePoint to mouse position
        direction = (mousePos - player.transform.position).normalized;
        //float angle = Vector2.Angle(player.transform.position.normalized, mousePos.normalized);
        print(player.transform.position);
        print(mousePos);
        //print(angle);

        //Quaternion targetRotation = Quaternion.LookRotation(direction);

        //transform.Rotate(0,0,angle);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void FixedUpdate()
    {
        if (homing)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
        RB.MovePosition(RB.position + direction * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            Debug.Log("hit something");
            Object.Destroy(gameObject);
        }
    }

}
