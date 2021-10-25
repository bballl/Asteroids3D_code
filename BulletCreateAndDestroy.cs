using UnityEngine;
using System.Collections;

namespace Asteroids
{
    internal sealed class BulletCreateAndDestroy
    {
        private GameObject _bulletPrefab;
        private ViewServices _viewServices;

        public BulletCreateAndDestroy(ViewServices viewServices)
        {
            _bulletPrefab = Resources.Load("Ammunition/Bullet") as GameObject;
            _viewServices = viewServices;
        }

        public GameObject CreateBullet()
        {
            return _viewServices.Create(_bulletPrefab);
        }

        public void DestroyBullet(GameObject bullet)
        {
            _viewServices.Destroy(bullet);
        }
    }
}

