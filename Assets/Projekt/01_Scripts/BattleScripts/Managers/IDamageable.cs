using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int dmg);
    bool IsAlive { get; }

    GameObject RelatedGameObject { get; }
}
