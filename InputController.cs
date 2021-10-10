using UnityEngine;

namespace Asteroids
{
    internal class InputController
    {

        public bool GetRocketStartButton()
        {
            return Input.GetButtonDown("Fire2");
        }
    }
}
