using UnityEngine;

namespace ObjectPool
{
    internal interface IViewServices
    {
        void Create(GameObject prefab);
        void Destroy(GameObject prefab);
    }
}
