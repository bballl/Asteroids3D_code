using System;

namespace AsteroidsState.Observer.ExampleFirst
{
    public interface IHit
    {
        event Action<float> OnHitChange;
        void Hit(float damage);
    }
}
