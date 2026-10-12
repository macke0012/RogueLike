namespace RougeLike.Models.Enemies;

public class Rat(int x, int y, char symbol, int health, string name) : Enemy(x, y, symbol, ConsoleColor.Yellow, health, name)
{
    public override void Update(List<LevelElement> elements)
    {
        Position[] directions =
        [
            new() { X = -1, Y = 0 },
            new() { X = 1, Y = 0 },
            new() { X = 0, Y = -1 },
            new() { X = 0, Y = 1 }
        ];

        List<Position> free = directions.Where(direction => !WillCollide(direction, elements)).ToList();

        // Boxed in on all sides: stay put this turn.
        if (free.Count == 0) return;

        Move(free[Random.Shared.Next(free.Count)]);
   
        
    }

    
}