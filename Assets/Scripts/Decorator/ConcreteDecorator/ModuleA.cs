public class ModuleA : ShipDecorator
{
    public ModuleA(Ship ship) : base(ship) { }

    public override float MaxShield => ship.MaxShield + 50;
}
