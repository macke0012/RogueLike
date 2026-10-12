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

    
}