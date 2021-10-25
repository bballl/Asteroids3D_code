using UnityEngine;

namespace AsteroidsState
{
    public sealed class StateRise : IState
    {
        public StateRise()
        {
            Debug.Log("Взлет");
        }
    }
}
