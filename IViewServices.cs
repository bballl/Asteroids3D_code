using UnityEngine;

namespace Asteroids
{
    internal interface IViewServices
    {
        void Create(GameObject prefab);
        void Destroy(GameObject prefab);
    }
}
