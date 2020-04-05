using System.Collections.Generic;

public abstract class Ship
{
    public Ship() { }

    public abstract float MaxHealth { get; }

    public abstract float MaxShield { get; }

    public abstract float ShieldRecoverySpeed { get; }

    public abstract float WeaponsReloadKoeff { get; }

    public abstract List<Weapon> Weapons { get; }

}