using UnityEngine;

namespace AsteroidsState
{
    public sealed class Listener
    {
        public void Add(Player player)
        {
            player.Info += PlayerStateInfo;
        }

        public void Remove(Player player)
        {
            player.Info -= PlayerStateInfo;
        }

        private void PlayerStateInfo()
        {
            Debug.Log("");
        }

    }
}