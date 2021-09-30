//using UnityEngine;

//namespace Asteroids
//{
//    internal abstract class Enemy : MonoBehaviour
//    {
//        public Health Health { get; private set; }

//        public static Asteroid CreateAsteroidEnemy(Health hp)
//        {
//            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

//            enemy.Health = hp;

//            return enemy;
//        }
//    }
//}

using UnityEngine;

namespace Asteroids
{
    internal abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        public Health Health { get; protected set; }

        //использование статического фабричного метода создания астероида
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/AsteroidBlue"));

            enemy.Health = hp;

            return enemy;
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
    }
}
