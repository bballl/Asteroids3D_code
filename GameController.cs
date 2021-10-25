using UnityEngine;
using System;

namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        private Facade _facade;
        private Data _data;
        
        private Rigidbody _rigidbody => _facade.Rigidbody;
        private Ship Ship => _facade.Ship;
        private Shooting Shooting => _facade.Shooting;
        private RocketStart RocketStart => _facade.RocketStart;

        public float _time = 0f;
        public event Action Test;

        private void Start()
        {
            Initialization();
        }

        private void Update()
        {
            Shooting.ShotLogic(_facade.Barrel, _data.Force);
            RocketStart.RocketStartLogic(_facade.Barrel, _data.Force);
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
        }

    }
}

