using UnityEngine;

namespace AsteroidsState
{
    public sealed class StateLanding : IState
    {
        public string Info()
        {
            //Debug.Log("Посадка");
            var info = "Посадка";
            return info;
        }
    }
}
