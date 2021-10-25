using UnityEngine;

namespace Asteroids
{
    public class StartShipModification : MonoBehaviour
    {
        private ShipData _shipData;

        private void Start()
        {
            StartModification();
        }
        
        public void StartModification()
        {
            _shipData = new ShipData();

            Debug.Log(_shipData.Attack);
            Debug.Log(_shipData.CurrentDefense);
            Debug.Log("----------------");

            var root = new ShipModifier(_shipData);
            root.Add(new AddAttackModifier(_shipData));
            root.Add(new AddDefenseModifier(_shipData));
            root.Handle();

            Debug.Log(_shipData.Attack);
            Debug.Log(_shipData.CurrentDefense);
        }
    }
}

