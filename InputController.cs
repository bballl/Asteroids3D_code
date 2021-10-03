using UnityEngine;

namespace Asteroids
{
    internal class InputController : MonoBehaviour
    {
        private float _jumpButton;

        public float GetHorizontal()
        {
            return Input.GetAxis("Horizontal");
        }

        public float GetVertical()
        {
            return Input.GetAxis("Vertical");
        }

        public bool GetJumpButton()
        {
            _jumpButton = Input.GetAxis("Jump");

            if (_jumpButton > 0)
            {
                return true;
            }
            else return false;
        }
        
        public bool GetFireButton()
        {
            return Input.GetButtonDown("Fire1");
        }
    }
}


