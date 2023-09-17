public class ExplosiveBulletBonus : Bonus
{
    public override BonusType BonusType => BonusType.Weapon;

    public override void ProcessBonus(PlayerController player)
    {
        Bullet bullet = BulletFactory.CreateBulletOfType(BulletType.Explosive);

        player.Inventory.SetBonusWeapon(bullet);
    }
}
