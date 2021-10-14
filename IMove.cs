namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void MovementLogic(UnityEngine.Rigidbody rigidbody, float speed);
    }
}