using UnityEngine;

public class PlayerMovementCheck : MonoBehaviour
{
    private Player _player;
    private Rigidbody2D _playerRB;
    private Vector2 movement;
    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0 && movement.y == 0)
        {
            _player.SetMovingStatus(false);
        }
        else
        {
            _player.SetMovingStatus(true);
        }
    }
}
