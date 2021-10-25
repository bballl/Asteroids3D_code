using UnityEngine;

namespace AsteroidsState
{
    public sealed class StateNeutral : IState
    {
        public StateNeutral()
        {
            Debug.Log("Ожидание");
        }
    }
}
