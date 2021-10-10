using UnityEngine;
using System;

namespace Asteroids
{
    //висит на префабе AsteroidPrototype
    //сделал мофификаторы полей public, чтобы было удобнее отслеживать изменения переменных
    internal sealed class AsteroidPrototype : MonoBehaviour
    {
        public AsteroidPrototypeData _asteroidPrototypeData;
        public AsteroidPrototypeHp _hp;
        public int _speed;
        public int _damage;
        public Vector3 _direction;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _asteroidPrototypeData = new AsteroidPrototypeData();
            SetData(_asteroidPrototypeData, _hp, _speed);

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(_direction * _speed, ForceMode.Force);
        }

        public void SetData(AsteroidPrototypeData data, AsteroidPrototypeHp hp, int speed)
        {
            _hp = data._hp;
            _speed = data._speed;
            _damage = data._damage;
            //_direction = data._direction;
        }
    }
}
