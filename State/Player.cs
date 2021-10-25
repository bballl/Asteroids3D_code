using UnityEngine;
using System;

namespace AsteroidsState
{
    public sealed class Player
    {
        public event Func<string> Info;
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
                //_state.Info();
                Debug.Log("State: " + _state.GetType().Name);
            }
        }
    }
}
