using RougeLike.Interfaces;

namespace RougeLike.Models.Enemies;

public abstract class Enemy(int x, int y, char symbol, ConsoleColor color, int health, string name) : LevelElement(x, y, symbol, color), IMovable
{
    public int Health = health;
    public string Name = name;

    public Position GetRandomDirection()
    {
        return Random.Shared.Next(4) switch
        {
            0 => new Position { X = -1, Y = 0 },
            1 => new Position { X = 1, Y = 0 },
            2 => new Position { X = 0, Y = -1 },
            3 => new Position { X = 0, Y = 1 },
            _ => throw new Exception("Invalid Range")

        };
    }

    public abstract void Update(List<LevelElement> elements);
}