using UnityEngine;

namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        //[SerializeField] private GameObject _bullet;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private float _force;
        [SerializeField] private float _jumpForce;

        private ViewServices _viewServices;
        private Bullet _bullet;
        private Camera _camera;
        private Transform _barrel;
        private Rigidbody _rigidbody;
        private Ship _ship;
        private Shooting _shooting;
        private RocketStart _rocketStart;
        private GameObject _player;
        private float _asteroidMaxHp = 100.0f;
        private float _asteroidCurrentHp = 100.0f;

        private void Start()
        {
            Initialization();
            CreateEnemyObjects();
        }

        private void Update()
        {
            _shooting.ShotLogic(_barrel, _force);
            _rocketStart.RocketStartLogic(_barrel, _force);
        }

        private void FixedUpdate()
        {
            _ship.MovementLogic(_rigidbody, _speed);
            _ship.JumpLogic(_rigidbody, _jumpForce);
        }

        private void Initialization()
        {
            _camera = Camera.main;
            _viewServices = new ViewServices();
            _bullet = new Bullet(_viewServices);
            _shooting = new Shooting(_bullet);
            _rocketStart = new RocketStart();

            _player = Instantiate(Resources.Load("Ship", typeof(GameObject))) as GameObject;
            _rigidbody = _player.GetComponent<Rigidbody>();

            var moveShip = new MoveShip(_speed);
            var jumpShip = new JumpShip();

            _ship = new Ship(moveShip, jumpShip);
            
            _barrel = _player.GetComponent<Transform>().Find("Barrel");
        }

        private void CreateEnemyObjects()
        {
            Enemy.CreateAsteroidEnemy(new Health(_asteroidMaxHp, _asteroidCurrentHp));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(_asteroidMaxHp, _asteroidCurrentHp));

            Enemy.Factory = factory;
            Enemy.Factory.CreateAsteroidGreen(new Health(_asteroidMaxHp, _asteroidCurrentHp));
        }
    }
}

