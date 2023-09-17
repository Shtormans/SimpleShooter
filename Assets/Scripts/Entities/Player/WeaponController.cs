using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private BulletPool _pool;
    private PlayerController _player;
    private InventorySystem _inventory;

    private void Awake()
    {
        _pool = new BulletPool();
        _player = GetComponent<PlayerController>();
        _inventory = GetComponent<InventorySystem>();
    }

    public void Shoot()
    {
        var bullet = _pool.GetBulletOfType(_inventory.CurrentBulletType);

        bullet.UseWeapon(_player);
    }

    public void ActivateBonus()
    {
        if (_inventory.BonusWeapon == null)
        {
            return;
        }

        _inventory.BonusWeapon.UseWeapon(_player);
    }
}
