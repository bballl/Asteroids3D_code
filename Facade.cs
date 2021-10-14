using UnityEngine;

namespace Asteroids
{
    internal sealed class Facade
    {

        public Data _data;
        public Ship _ship;
        public GameObject _player;
        public Rigidbody _rigidbody;
        public Transform _barrel;

        public ViewServices _viewServices;
        public Bullet _bullet;
        public Shooting _shooting;
        public RocketStart _rocketStart;

        private float Speed => _data.Speed;

        private float AsteroidMaxHp => _data.AsteroidMaxHp;
        private float AsteroidCurrentHp => _data.AsteroidCurrentHp;

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
            _ship = new Ship(moveShip, jumpShip);
            _player = Object.Instantiate(Resources.Load("Ship", typeof(GameObject))) as GameObject;
            _rigidbody = _player.GetComponent<Rigidbody>();
            _barrel = _player.GetComponent<Transform>().Find("Barrel");
        }

        public void ShootingInitialization()
        {
            _viewServices = new ViewServices();
            _bullet = new Bullet(_viewServices);
            _shooting = new Shooting(_bullet);
            _rocketStart = new RocketStart();
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
