using UnityEngine;
using System.Collections;
using System;

namespace Asteroids
{
    //висит на префабе Bullet
    internal sealed class BulletTimer : MonoBehaviour
    {
        public event Action Test;
        public delegate void TestD (GameObject go);

        public bool Flag { get; private set; }
        private float _time = 0f;
        
        private void Start()
        {
            Flag = false;
            StartCoroutine(TimerForBullet());
        }

        private IEnumerator TimerForBullet()
        {
            Debug.Log("Таймер стартовал");
            yield return new WaitForSeconds(3.0f);
            _time = 3.0f;
           
            Test();
            
        }

        public bool GetFlag()
        {
            return Flag = true;
        }
    }
}
