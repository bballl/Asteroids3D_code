namespace Asteroids
{
    internal sealed class AddDefenseModifier : ShipModifier
    {

        public AddDefenseModifier(ShipData shipData) : base(shipData) { }

        public override void Handle()
        {
            if (_shipData.CurrentDefense <= _shipData.MaxDefense)
            {
                _shipData.CurrentDefense++;
            }
            base.Handle();
        }
    }
}
