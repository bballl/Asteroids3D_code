using UnityEngine;

//паттерн Прототип
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
            SetData(_asteroidPrototypeData);

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(_direction * _speed, ForceMode.Force);
        }

        public void SetData(AsteroidPrototypeData data)
        {
            _hp = data._hp;
            _speed = data._speed;
            _damage = data._damage;
        }
    }
}
