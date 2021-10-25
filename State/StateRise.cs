using UnityEngine;

namespace AsteroidsState
{
    public sealed class StateRise : IState
    {
        public string Info()
        {
            //Debug.Log("Взлет");
            var info = "Взлет";
            return info;
        }
    }
}
