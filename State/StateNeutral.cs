using UnityEngine;

namespace AsteroidsState
{
    public sealed class StateNeutral : IState
    {
        public string Info()
        {
            //Debug.Log("Ожидание");
            var info = "Ожидание";
            return info;
        }
    }
}
