using UnityEngine;

public interface IenemyMoveable
{
    Rigidbody2D RB { get; set; }
    bool IsFacingRight { get; set; }
    void MoveEnemy(Vector2 velocity);
    void CheckForLeftOrRightFacing(Vector2 velocity);
}
