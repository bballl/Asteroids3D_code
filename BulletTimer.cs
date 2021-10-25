using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletTimer : MonoBehaviour
    {
        public float _time = 0f;
        private GameObject _gc;
        
        private void Start()
        {
            _gc = GameObject.FindGameObjectWithTag("GameController");
            var a = _gc.GetComponent<GameController>();
            a.Test += TTimer;
        }

        private void FixedUpdate()
        {
            //TTimer();
            DestroyBullet();
        }

        public void TTimer()
        {
            _time = _time + Time.deltaTime;
            //Debug.Log(_time);
        }

        public void DestroyBullet()
        {
            if (_time >= 3.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
