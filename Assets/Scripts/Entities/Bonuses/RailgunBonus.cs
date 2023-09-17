public class RailgunBonus : Bonus
{
    public override BonusType BonusType => BonusType.Weapon;

    public override void ProcessBonus(PlayerController player)
    {
        Railgun railgun = new();

        player.Inventory.SetBonusWeapon(railgun);
    }
}
