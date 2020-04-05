public class ModuleC : ShipDecorator
{
    public ModuleC(Ship ship) : base(ship) { }

    public override float WeaponsReloadKoeff => ship.WeaponsReloadKoeff - 0.2f;
}
