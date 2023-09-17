using UnityEngine;

public abstract class Bullet : MonoBehaviour, IWeapon
{
    protected float _distanceBeforeDisappear = 100f;

    protected PlayerController _sender;
    protected Vector3 _startPosition;

    public abstract BulletType Type { get; }

    protected abstract void Deactivate();

    public void UseWeapon(PlayerController sender)
    {
        _sender = sender;
        transform.position = sender.HeadPosition;
        transform.rotation = sender.HeadRotation;

        gameObject.SetActive(true);
    }

    protected void DeleteOnDistance()
    {
        if (Vector3.Distance(_startPosition, transform.position) >= _distanceBeforeDisappear)
        {
            Deactivate();
        }
    }

    protected bool CheckForPlayerHit(GameObject enemyObject)
    {
        return enemyObject.TryGetComponent(out PlayerController enemy);
    }
}
