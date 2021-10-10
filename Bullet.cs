using UnityEngine;
using System.Collections;

namespace Asteroids
{
    internal sealed class Bullet
    {
        private GameObject _bulletPrefab;
        private ViewServices _viewServices;
        

        public Bullet(ViewServices viewServices)
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
            Debug.Log("метод дестрой буллет");
        }

        public void TestMethod()
        {
            Debug.Log("метод TestMethod");
        }
    }
}

