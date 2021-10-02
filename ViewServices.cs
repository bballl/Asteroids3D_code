using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace ObjectPool
{
    internal sealed class ViewServices : IViewServices
    {
        private readonly Dictionary<string, ObjectPool> _viewCache
            = new Dictionary<string, ObjectPool>(12);

        public void Create(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            viewPool.Pop();
        }

        public void Destroy(GameObject prefab)
        {
            _viewCache[prefab.name].Push(prefab);
        }
    }

    
}
