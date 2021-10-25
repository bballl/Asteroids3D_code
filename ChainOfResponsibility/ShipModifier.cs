namespace Asteroids
{
    internal class ShipModifier
    {
        protected ShipData _shipData;
        public ShipModifier Next;

        public ShipModifier(ShipData shipdata)
        {
            _shipData = shipdata;
        }

        public void Add(ShipModifier shipMod)
        {
            if (Next != null)
            {
                Next.Add(shipMod);
            }
            else
            {
                Next = shipMod;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}
