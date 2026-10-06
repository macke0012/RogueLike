namespace RougeLike.Models.Enemies;

public class Rat(int x, int y, char symbol, int health, string name) : Enemy(x, y, symbol, ConsoleColor.Yellow, health, name)
{
    public override void Update(List<LevelElement> elements)
    {
        Position direction = GetRandomDirection();
        while (WillCollide(direction, elements))
        {
            direction = GetRandomDirection();
        }
        
        
        Move(direction);
        
    }

    Position GetRandomDirection()
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