namespace RougeLike.Models.Enemies;

public abstract class Enemy(int x, int y, char symbol, ConsoleColor color, int health, string name) : LevelElement(x, y, symbol, color)
{
    public int Health = health;
    public string Name = name;

    public Position GetRandomDirection()
    {
        return Random.Shared.Next(4) switch
        {
            0 => new Position(-1, 0),
            1 => new Position(1, 0),
            2 => new Position(0, -1),
            3 => new Position(0, 1),
            _ => throw new Exception("Invalid Range")

        };
    }

    
   
}