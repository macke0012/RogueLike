namespace RougeLike.Interfaces;

public interface IAlive
{
    int Health { get; }
    void TakeDamage(int damage);
    bool IsDead();
}