using UnityEngine;

namespace AsteroidsState
{
    public sealed class StateLanding : IState
    {
        public StateLanding()
        {
            Debug.Log("Посадка");
        }
    }
}
