using UnityEngine;
using System.Threading;
using System.Collections;

namespace Asteroids
{
    internal sealed class Shooting : InputController
    {
        private Bullet _bullet;
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

                var rigidbody = bullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(barrel.up * force);

                StartCoroutine(DeleteBullet(bullet));
            }
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


