namespace Asteroids
{
    internal class ShipData
    {
        public int Attack = 1;
        public int CurrentDefense = 10;
        public int MaxDefense { get; } = 20;
        public int AttackModificationValue { get; } = 5;
    }
}

