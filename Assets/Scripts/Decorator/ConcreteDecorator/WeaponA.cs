using System.Collections.Generic;

public class WeaponA : ShipDecorator
{
    public WeaponA(Ship ship) : base(ship) { }

    public override List<Weapon> Weapons
    {
        get
        {
            return new List<Weapon>(ship.Weapons) { new Weapon(5, 3) };
        }
    }
}