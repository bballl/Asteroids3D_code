using UnityEngine;

//паттерн Строитель
namespace Asteroids
{
    internal sealed class RocketStart : InputController
    {
        private RocketBuilder _rocketBuilder;

        public void RocketStartLogic(Transform transform, float force)
        {
            if (GetRocketStartButton())
            {
                _rocketBuilder = new RocketBuilder();
                var rocket = _rocketBuilder._rocket;

                rocket.transform.position = transform.position;
                rocket.transform.rotation = transform.rotation;
                rocket.SetActive(true);

                var rigidbody = rocket.GetComponent<Rigidbody>();
                rigidbody.AddForce(transform.up * force);
            }
        }
    }
}
