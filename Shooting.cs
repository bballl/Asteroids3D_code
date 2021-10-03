using UnityEngine;
using System.Threading;
using System.Collections;

namespace Asteroids
{
    internal sealed class Shooting : InputController
    {
        private CreateBullet _createBullet;
        private float _waitTime = 3.0f;

        public Shooting()
        {
            _createBullet = new CreateBullet();
        }

        public void ShotLogic(Transform barrel, float force)
        {
            if (GetFireButton())
            {
                var bullet = _createBullet.Create();
                bullet.transform.position = barrel.position;
                bullet.transform.rotation = barrel.rotation;
                bullet.SetActive(true);

                var rigidbody = bullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(barrel.up * force);
            }
        }
    }
}
