using UnityEngine;

namespace Asteroids
{
    internal sealed class Ship : IMove, IJump
    {
        public float Speed => _moveImplementation.Speed; //public float Speed { get { return _moveImplementation.Speed; } }
        
        private readonly IMove _moveImplementation;
        private readonly IJump _jumpImplementation;

        public Ship(IMove moveImplementation, IJump jumpImplementation)
        {
            _moveImplementation = moveImplementation;
            _jumpImplementation = jumpImplementation;
        }

        public void MovementLogic(Rigidbody rigidbody, float speed)
        {
            _moveImplementation.MovementLogic(rigidbody, Speed);
        }

        public void JumpLogic(Rigidbody rigidbody, float jumpForce)
        {
            _jumpImplementation.JumpLogic(rigidbody, jumpForce);
        }
    }
}
