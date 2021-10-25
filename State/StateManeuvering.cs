using UnityEngine;

namespace AsteroidsState
{
    public sealed class StateManeuvering : IState
    {
        public string Info()
        {
            //Debug.Log("Маневрирование");
            var info = "Маневрирование";
            return info;
        }
    }
}