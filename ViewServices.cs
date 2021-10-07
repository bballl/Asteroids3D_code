using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class ViewServices
    {
        private readonly Dictionary<string, ObjectPool> _viewCache
            = new Dictionary<string, ObjectPool>(12);

        public GameObject Create(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            return viewPool.Pop();
        }

        public void Destroy(GameObject prefab)
        {
            _viewCache[prefab.name].Push(prefab);
        }
    }

    
}
