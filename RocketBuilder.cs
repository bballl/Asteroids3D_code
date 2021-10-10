using UnityEngine;

//паттерн Строитель
namespace Asteroids
{
    internal sealed class RocketBuilder
    {
        public GameObject _rocket;
        private float mass = 1.0f;

        public RocketBuilder()
        {
            var _gameObjectBuilder = new GameObjectBuilder();
            var _rocketComponents = new RocketPrefabAndComponents();

            _rocket = _gameObjectBuilder.Visual.
                Name("Rocket").
                MeshFilter(_rocketComponents._mesh).
                MeshRenderer(_rocketComponents._material).
                Physics.
                Rigidbody(mass).
                CapsuleCollider();
            _rocket.SetActive(false);
        }
    }
}
