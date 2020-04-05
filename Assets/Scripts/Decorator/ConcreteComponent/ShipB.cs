using System.Collections.Generic;

public class ShipB : Ship
{
    public ShipB() : base() { }

    public override float MaxHealth => 60;

    public override float MaxShield => 120;

    public override float ShieldRecoverySpeed => 1;

    public override float WeaponsReloadKoeff => 1;

    public override List<Weapon> Weapons => new List<Weapon>();
}