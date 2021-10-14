using UnityEngine;

namespace Asteroids
{
    internal sealed class JumpShip : InputController, IJump
    {
        public void JumpLogic(Rigidbody rigidbody, float jumpForce)
        {
            if (GetJumpButton())
            {
                rigidbody.AddForce(Vector3.up * jumpForce);
            }
        }
    }
}

