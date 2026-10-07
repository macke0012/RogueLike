namespace RougeLike.Models.Enemies;

public class Snake(int x, int y, char symbol, int health, string name) : Enemy(x, y, symbol, ConsoleColor.DarkGreen, health, name)
{
    public override void Update()
    {
        while (GetDistanceToPlayer() <= 2)
        {
            var dir = GetRandomDirection();
            while (WillCollide(dir))
            {
                dir = GetRandomDirection();
            }
            
            Move(dir);
        }
        base.Update();
    }
    
    

    
}