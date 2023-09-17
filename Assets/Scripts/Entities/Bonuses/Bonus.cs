using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    private const float _bonusRadius = 1f;

    public abstract BonusType BonusType { get; }
    public abstract void ProcessBonus(PlayerController player);

    private void Awake()
    {
        var collider = gameObject.AddComponent<SphereCollider>();
        collider.radius = _bonusRadius;
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            ProcessBonus(player);
            Destroy(gameObject);
        }
    }
}
