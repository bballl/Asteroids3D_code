using UnityEngine;

namespace Asteroids
{
    //висит на префабе астероида
    internal sealed class Asteroid : Enemy
    {
        private int _speed = 1;
        private int _damage = 1;
        private Vector3 _direction;
        private Rigidbody _rigidbody;

        private void FixedUpdate()
        {
            _rigidbody = GetComponent<Rigidbody>();
            var minValue = -1;
            var maxValue = 2;
            _direction = new Vector3(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue), Random.Range(minValue, maxValue));
            _rigidbody.AddForce(_direction * _speed, ForceMode.Force);
        }
    }
}
