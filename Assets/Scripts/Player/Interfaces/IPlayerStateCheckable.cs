using UnityEngine;

public interface IPlayerStateCheckable
{
    bool IsMoving { get; set; }

    bool IsAttacking { get; set; }

    void SetMovingStatus(bool IsMoving);

    void SetAttackingStatus(bool IsAttacking);
}
