using UnityEngine;
using System;

//паттерн Прототип
namespace Asteroids
{
    [Serializable]
    internal sealed class AsteroidPrototypeData
    {
        public AsteroidPrototypeHp _hp;
        public int _speed = 15;
        public int _damage = 2;

        public AsteroidPrototypeData()
        {
            _hp = new AsteroidPrototypeHp();
        }
    }
}
