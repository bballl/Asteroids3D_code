using UnityEngine;

namespace Asteroids
{
    internal sealed class GameObjectVisualBuilder : GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectVisualBuilder MeshFilter(Mesh mesh)
        {
            var component = GetOrAddComponent<MeshFilter>();
            component.mesh = mesh;
            return this;
        }

        public GameObjectVisualBuilder MeshRenderer(Material material)
        {
            var component = GetOrAddComponent<MeshRenderer>();
            component.material = material;
            return this;
        }
    }
}
