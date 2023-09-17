using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public IWeapon BonusWeapon { get; private set; }
    public BulletType CurrentBulletType => BulletType.Classic;

    private void Awake()
    {
        BonusWeapon = null;
    }

    public void SetBonusWeapon(IWeapon bonusWeapon)
    {
        BonusWeapon = bonusWeapon;
    }
}
