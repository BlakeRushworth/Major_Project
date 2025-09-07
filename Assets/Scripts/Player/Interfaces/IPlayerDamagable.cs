using UnityEngine;

public interface IPlayerDamagable
{
    void Damage(float damageamount);

    void Die();

    float MaxHealth { get; set; }

    float CurrentHealth { get; set; }
}
