public class ModuleB : ShipDecorator
{
    public ModuleB(Ship ship) : base(ship) { }

    public override float MaxHealth => ship.MaxHealth + 50;
}