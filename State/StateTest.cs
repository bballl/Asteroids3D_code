using UnityEngine;
using System.Collections;

namespace AsteroidsState
{
    public sealed class StateTest : MonoBehaviour
    {
        private Player _player;
        private float _waitTime = 3.0f;
        
        private void Start()
        {
            _player = new Player(new StateNeutral());
        }

        private void Update()
        {
            ChangeState();
        }

        private IEnumerator ShipTimer()
        {
            yield return new WaitForSeconds(_waitTime);
            _player.State = new StateManeuvering();

            yield return new WaitForSeconds(_waitTime);
            _player.State = new StateLanding();
        }

        public void ChangeState()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _player.State = new StateRise();
                StartCoroutine(ShipTimer());
            }
        }
    }
}
