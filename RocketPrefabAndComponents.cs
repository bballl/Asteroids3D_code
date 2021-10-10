using UnityEngine;

namespace Asteroids
{
    internal sealed class RocketPrefabAndComponents
    {
        public Mesh _mesh;
        public MeshFilter _meshFilter;
        public MeshRenderer _meshRenderer;
        public Material _material;

        private GameObject _rocketPrefab;

        public RocketPrefabAndComponents()
        {
            _rocketPrefab = Resources.Load("Ammunition/Rocket") as GameObject;
            
            _meshFilter = _rocketPrefab.GetComponent<MeshFilter>();
            _mesh = _meshFilter.sharedMesh;
            _meshRenderer = _rocketPrefab.GetComponent<MeshRenderer>();
            _material = Resources.Load("Materials/RocketMaterial") as Material;
        }
    }
}
