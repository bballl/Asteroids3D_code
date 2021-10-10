using UnityEngine;

namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private float _force;
        
        private Transform _barrel;
        private RocketStart _rocketStart;
        private GameObject _player;

        private void Start()
        {
            Initialization();
        }

        private void Update()
        {
            _rocketStart.RocketStartLogic(_barrel, _force);
        }

        private void Initialization()
        {
            _rocketStart = new RocketStart();
            _player = Instantiate(Resources.Load("Ship", typeof(GameObject))) as GameObject;
            _barrel = _player.GetComponent<Transform>().Find("Barrel");
        }
    }
}

