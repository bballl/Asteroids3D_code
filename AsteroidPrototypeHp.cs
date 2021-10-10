using System;

//паттерн Прототип
namespace Asteroids
{
    [Serializable]
    internal sealed class AsteroidPrototypeHp
    {
        public float MaxHP;
        public float CurrentHP = 100;

        public override string ToString()
        {
            return $"MaxHP {MaxHP} CurrentHP {CurrentHP}";
        }
    }
}
