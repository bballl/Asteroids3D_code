using UnityEngine;

namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        //[SerializeField] private GameObject _bullet;
        //[SerializeField] private float _speed;
        //[SerializeField] private float _acceleration;
        
        //[SerializeField] private float _force;
        //[SerializeField] private float _jumpForce;

        private Facade _facade;
        private Data _data;

        //private ViewServices _viewServices;
        //private Bullet _bullet;
        
        
        private Rigidbody _rigidbody => _facade._rigidbody;
        private Ship Ship => _facade._ship;
        private Shooting Shooting => _facade._shooting;
        private RocketStart RocketStart => _facade._rocketStart;
        

        private void Start()
        {
            Initialization();
            //facade.CreateEnemyObjects();
        }

        private void Update()
        {
            Shooting.ShotLogic(_facade._barrel, _data.Force);
            RocketStart.RocketStartLogic(_facade._barrel, _data.Force);
        }

        private void FixedUpdate()
        {
            Ship.MovementLogic(_rigidbody, _data.Speed);
            Ship.JumpLogic(_rigidbody, _data.JumpForce);
        }

        private void Initialization()
        {
            _facade = new Facade();
            _data = new Data();

            //_ship = _facade._ship;
            //_player = _facade._player;
            //_rigidbody = _facade._rigidbody;


            
            //_viewServices = new ViewServices();
            //_bullet = new Bullet(_viewServices);
            //_shooting = new Shooting(_bullet);
            //_rocketStart = new RocketStart();

            //_player = Instantiate(Resources.Load("Ship", typeof(GameObject))) as GameObject;
            //_rigidbody = _player.GetComponent<Rigidbody>();

            //var moveShip = new MoveShip(_speed);
            //var jumpShip = new JumpShip();

            //_ship = new Ship(moveShip, jumpShip);
            
            //_barrel = _player.GetComponent<Transform>().Find("Barrel");
        }

        //private void CreateEnemyObjects()
        //{
        //    Enemy.CreateAsteroidEnemy(new Health(_asteroidMaxHp, _asteroidCurrentHp));

        //    IEnemyFactory factory = new AsteroidFactory();
        //    factory.Create(new Health(_asteroidMaxHp, _asteroidCurrentHp));

        //    Enemy.Factory = factory;
        //    Enemy.Factory.CreateAsteroidGreen(new Health(_asteroidMaxHp, _asteroidCurrentHp));
        //}
    }
}

