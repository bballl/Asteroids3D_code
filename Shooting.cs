using UnityEngine;
using System.Threading;
using System.Collections;

namespace Asteroids
{
    internal sealed class Shooting : InputController
    {
        private BulletCreateAndDestroy _bulletCreateAndDestroy;
        private float _waitTime = 3.0f;

        public Shooting(BulletCreateAndDestroy bullet)
        {
            _bulletCreateAndDestroy = bullet;
        }

        public void ShotLogic(Transform barrel, float force)
        {
            if (GetFireButton())
            {
                var bullet = _bulletCreateAndDestroy.CreateBullet();
                bullet.transform.position = barrel.position;
                bullet.transform.rotation = barrel.rotation;
                bullet.SetActive(true);

                var rigidbody = bullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(barrel.up * force);
            }
        }

        public IEnumerator DeleteBullet(GameObject bullet)
        {
            Debug.Log("короутина старт");
            yield return new WaitForSeconds(_waitTime);
            _bulletCreateAndDestroy.DestroyBullet(bullet);
        }
    }
}


