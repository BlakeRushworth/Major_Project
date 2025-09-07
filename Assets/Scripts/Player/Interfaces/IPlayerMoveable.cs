using UnityEngine;

public interface IPlayerMoveable
{
    Rigidbody2D RB { get; set; }

    bool IsFacingRight { get; set; }

    void MovePlayer(Vector2 velocity);
    void CheckForLeftOrRightFacing(Vector2 velocity);
}
