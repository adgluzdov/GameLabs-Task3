using System.Collections.Generic;

public class ShipA : Ship
{
    public ShipA() : base() { }

    public override float MaxHealth => 100;

    public override float MaxShield => 80;

    public override float ShieldRecoverySpeed => 1;

    public override float WeaponsReloadKoeff => 1;

    public override List<Weapon> Weapons => new List<Weapon>();
}
