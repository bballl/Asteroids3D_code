using UnityEngine;

namespace Asteroids
{
    internal sealed class Facade
    {
        public Ship Ship { get; private set; }
        public GameObject Player { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public Transform Barrel { get; private set; }
        public Shooting Shooting { get; private set; }
        public RocketStart RocketStart { get; private set; }

        private float Speed => _data.Speed;
        private float AsteroidMaxHp => _data.AsteroidMaxHp;
        private float AsteroidCurrentHp => _data.AsteroidCurrentHp;

        private ViewServices _viewServices;
        private BulletCreateAndDestroy _bullet;
        private Data _data;

        public Facade()
        {
            _data = new Data();
            
            PlayerInitialization();
            ShootingInitialization();
            CreateEnemyObjects();
        }

        public void PlayerInitialization()
        {
            var moveShip = new MoveShip(Speed);
            var jumpShip = new JumpShip();
            Ship = new Ship(moveShip, jumpShip);
            Player = Object.Instantiate(Resources.Load("Ship", typeof(GameObject))) as GameObject;
            Rigidbody = Player.GetComponent<Rigidbody>();
            Barrel = GameObject.FindGameObjectWithTag("Barrel").transform;
        }

        public void ShootingInitialization()
        {
            _viewServices = new ViewServices();
            _bullet = new BulletCreateAndDestroy(_viewServices);
            Shooting = new Shooting(_bullet);
            RocketStart = new RocketStart();
        }

        public void CreateEnemyObjects()
        {
            Enemy.CreateAsteroidEnemy(new Health(AsteroidMaxHp, AsteroidCurrentHp));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(AsteroidMaxHp, AsteroidCurrentHp));

            Enemy.Factory = factory;
            Enemy.Factory.CreateAsteroidGreen(new Health(AsteroidMaxHp, AsteroidCurrentHp));
        }
    }
}
