using UnityEngine;
using System.Collections;

namespace Asteroids
{
    internal sealed class CreateBullet
    {
        private GameObject _bulletPrefab;
        private ViewServices _viewServices;

        public CreateBullet()
        {
            _bulletPrefab = Resources.Load("Ammunition/Bullet") as GameObject;
            _viewServices = new ViewServices();
        }

        public GameObject Create()
        {
            var bullet = _viewServices.Create(_bulletPrefab);
            return bullet;
        }
    }
}

