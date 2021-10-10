using UnityEngine;

//паттерн Строитель
namespace Asteroids
{
    internal sealed class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectPhysicsBuilder CapsuleCollider()
        {
            GetOrAddComponent<CapsuleCollider>();
            return this;
        }

        public GameObjectPhysicsBuilder Rigidbody(float mass)
        {
            var component = GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            return this;
        }
    }
}
