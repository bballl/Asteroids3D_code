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
//Роман, хочу попросить прокомментировать происходящее в 7-й строке.
//Если вместо нее написать так:
// public GameObjectVisualBuilder(GameObject gameObject)
// {
//     _gameObject = gameObject;
// }
//Получится то же самое или нет?
//Ведь GameObjectVisualBuilder, будучи наследником GameObjectBuilder, получает от него поле _gameObject ?
