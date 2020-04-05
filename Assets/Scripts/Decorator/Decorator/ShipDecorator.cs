using System.Collections.Generic;

public abstract class ShipDecorator : Ship
{
    protected Ship ship;

    public ShipDecorator(Ship ship) : base()
    {
        this.ship = ship;
    }

    public override float MaxHealth => ship.MaxHealth;

    public override float MaxShield => ship.MaxShield;

    public override float ShieldRecoverySpeed => ship.ShieldRecoverySpeed;

    public override float WeaponsReloadKoeff => ship.ShieldRecoverySpeed;

    public override List<Weapon> Weapons => ship.Weapons;
}
