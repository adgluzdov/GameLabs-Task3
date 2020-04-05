public class ModuleD : ShipDecorator
{
    public ModuleD(Ship ship) : base(ship) { }

    public override float ShieldRecoverySpeed => ship.ShieldRecoverySpeed + ship.ShieldRecoverySpeed * 0.2f;
}