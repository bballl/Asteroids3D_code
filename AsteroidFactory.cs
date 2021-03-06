using UnityEngine;

namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        //нестатический фабричный метод
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.DependencyInjectHealth(hp);

            return enemy;
        }

        public Enemy CreateAsteroidGreen (Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/AsteroidGreen"));

            enemy.DependencyInjectHealth(hp);

            return enemy;
        }
    }
}
