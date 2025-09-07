using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackCheck : MonoBehaviour
{

    private Player _player;
    private Rigidbody2D _playerRB;
    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            //print("hiiii, i clicked z");
            _player.SetAttackingStatus(true);
        }
        else
        {
            _player.SetAttackingStatus(false);
        }
    }
}
