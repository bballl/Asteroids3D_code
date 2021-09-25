﻿using UnityEngine;

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

        void Start()
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

        void Update()
        {
            _shooting.ShotLogic(_bullet, _barrel, _force);
        }

        void FixedUpdate()
        {
            _ship.MovementLogic(_rigidbody, _speed);
            _ship.JumpLogic(_rigidbody, _jumpForce);
        }
    }
}

