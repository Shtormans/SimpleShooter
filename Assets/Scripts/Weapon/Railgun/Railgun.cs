using UnityEngine;

public class Railgun : IWeapon
{
    [SerializeField] private float _maxDistance = 100f;

    public void UseWeapon(PlayerController sender)
    {
        RaycastHit[] raycastHits = Physics.RaycastAll(sender.HeadPosition, sender.HeadRotation.eulerAngles, _maxDistance);

        foreach (var hit in raycastHits)
        {
            if (hit.collider.gameObject.TryGetComponent(out EnemyController enemy))
            {
                enemy.TakeDamage();
            }
        }
    }
}
