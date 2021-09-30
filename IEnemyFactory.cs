namespace Asteroids
{
    internal interface IEnemyFactory
    {
        Enemy Create(Health hp);
        Enemy CreateAsteroidGreen(Health hp);
    }
}
