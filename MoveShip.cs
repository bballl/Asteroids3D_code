using UnityEngine;

namespace Asteroids
{
    internal class MoveShip : InputController, IMove
    {
        public float Speed { get; protected set; }

        public MoveShip(float speed)
        {
            Speed = speed;
        }

        public void MovementLogic(Rigidbody rigidbody, float Speed)
        {
            Vector3 movement = new Vector3(GetHorizontal(), 0.0f, GetVertical());
            rigidbody.AddForce(movement * Speed, ForceMode.Force);
        }
    }
}
