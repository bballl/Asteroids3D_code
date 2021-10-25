namespace Asteroids
{
    internal sealed class AddAttackModifier : ShipModifier
    {
        public AddAttackModifier(ShipData shipData) : base(shipData) { }

        public override void Handle()
        {
            _shipData.Attack += _shipData.AttackModificationValue;
            base.Handle();
        }
    }
}
