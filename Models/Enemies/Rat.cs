namespace RougeLike.Models.Enemies;

public class Rat(int x, int y, char symbol, int health, string name) : Enemy(x, y, symbol, ConsoleColor.Yellow, health, name)
{
    public override void Update()
    {
        Position direction = GetRandomDirection();
        while (WillCollide(direction))
        {
            direction = GetRandomDirection();
        }
        
        
        Move(direction);
        base.Update();
        
    }

    
}