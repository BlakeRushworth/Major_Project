using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D RB;

    Vector2 movement;
    void Start()
    {
        
    }

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        RB.MovePosition(RB.position + movement * moveSpeed * Time.deltaTime);
    }
}
