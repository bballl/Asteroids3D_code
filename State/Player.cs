using UnityEngine;

namespace AsteroidsState
{
    public sealed class Player
    {
        private IState _state;

        public Player(IState state)
        {
            State = state;
        }

        public IState State
        {
            set
            {
                _state = value;
                Debug.Log("State: " + _state.GetType().Name);
            }
        }
    }
}
