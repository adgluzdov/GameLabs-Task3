using System.Collections.Generic;

public class WeaponC : ShipDecorator
{
    public WeaponC(Ship ship) : base(ship) { }

    public override List<Weapon> Weapons
    {
        get
        {
            return new List<Weapon>(ship.Weapons) { new Weapon(20, 5) };
        }
    }
}
