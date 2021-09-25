using UnityEngine;

namespace Asteroids
{
    internal sealed class Shooting : InputController
    {
        private float _time = 3.0f;

        public void ShotLogic(GameObject bullet, Transform barrel, float force)
        {
            if (GetFireButton())
            {
                var temAmmunition = Object.Instantiate(bullet, barrel.position, barrel.rotation);
                var rigidbody = temAmmunition.GetComponent<Rigidbody>();
                rigidbody.AddForce(barrel.up * force);
                Object.Destroy(temAmmunition, _time);
            }
        }
    }
}
