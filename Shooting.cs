using UnityEngine;
using System;
using System.Collections;

namespace Asteroids
{
    internal sealed class Shooting : InputController
    {
        //public event Action ShootingEvent;
        private Bullet _bullet;
        private GameObject _bulletPrefab;
        private float _waitTime = 3.0f;

        public Shooting(Bullet bullet)
        {
            _bullet = bullet;
        }

        public void ShotLogic(Transform barrel, float force)
        {
            if (GetFireButton())
            {
                var bullet = _bullet.CreateBullet();
                bullet.transform.position = barrel.position;
                bullet.transform.rotation = barrel.rotation;
                bullet.SetActive(true);

                //_bulletPrefab = bullet;



                bullet.GetComponent<BulletTimer>().Test += _bullet.TestMethod;
                bullet.GetComponent<BulletTimer>().Test += TimeObserver;
                //bullet.GetComponent<BulletTimer>().Test += _bullet.DestroyBullet;

                var rigidbody = bullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(barrel.up * force);
            }


        }

        public void TimeObserver()
        {
            Debug.Log("TimeObserver стартовал");
            //_bullet.DestroyBullet(_bulletPrefab);
        }



        //При попытке вызвать DeleteBullet у меня возникает NullReferenceException. Я пытался и так и сяк,
        //переносил аналогичные действия с корутиной
        //в класс Bullet (сделав ему наследование от MonoBehaviour), но там все то же самое. Не могу понять в чем дело.
        public IEnumerator DeleteBullet(GameObject bullet)
        {
            Debug.Log("короутина старт");
            yield return new WaitForSeconds(_waitTime);
            _bullet.DestroyBullet(bullet);
        }
    }
}


