using UnityEngine;

namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private float _force;
        [SerializeField] private float _jumpForce;

        private Camera _camera;
        private Transform _barrel;
        private Rigidbody _rigidbody;
        private Ship _ship;
        private Shooting _shooting;
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
            _shooting.ShotLogic(_bullet, _barrel, _force);
        }

        private void FixedUpdate()
        {
            _ship.MovementLogic(_rigidbody, _speed);
            _ship.JumpLogic(_rigidbody, _jumpForce);
        }

        private void Initialization()
        {
            _camera = Camera.main;
            _player = Instantiate(Resources.Load("Ship", typeof(GameObject))) as GameObject;
            _rigidbody = _player.GetComponent<Rigidbody>();

            var moveShip = new MoveShip(_speed);
            var jumpShip = new JumpShip();

            _ship = new Ship(moveShip, jumpShip);
            _shooting = new Shooting();
            _barrel = _player.GetComponent<Transform>().Find("Barrel");
        }

        private void CreateEnemyObjects()
        {
            //запуск статического фабричного метода
            Enemy.CreateAsteroidEnemy(new Health(_asteroidMaxHp, _asteroidCurrentHp));

            //запуск нестатического фабричного метода
            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(_asteroidMaxHp, _asteroidCurrentHp));

            //можно этот класс вынести в статическое поле класса
            Enemy.Factory = factory;
            Enemy.Factory.CreateAsteroidGreen(new Health(_asteroidMaxHp, _asteroidCurrentHp));
        }
    }
}

