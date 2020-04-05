using System.Collections.Generic;

public class WeaponB : ShipDecorator
{
    public WeaponB(Ship ship) : base(ship) { }

    public override List<Weapon> Weapons
    {
        get
        {
            return new List<Weapon>(ship.Weapons) { new Weapon(4, 2) };
        }
    }
}