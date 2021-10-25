using UnityEngine;

namespace AsteroidsState
{
    public sealed class StateManeuvering : IState
    {
        public StateManeuvering()
        {
            Debug.Log("Маневрирование");
        }
    }
}