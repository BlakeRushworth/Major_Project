using UnityEngine;

public interface Idamageable
{

    void Damage(float damageAmount);

    void Die();

    float MaxHealth { get; set; }

    float CurrentHealth { get; set; }
}
