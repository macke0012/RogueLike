namespace RougeLike.Models;



public class Player(int x, int y, char symbol) : LevelElement(x, y, symbol, ConsoleColor.Magenta)
{
    public void Update(List<LevelElement> elements)
    {
        Position direction = new();
        do
        {
            direction = GetPlayerDirection();
            if (!WillCollide(direction, elements)) break;

        } while (true);
       
        
        if(Position.X + direction.X < 0 || Position.Y + direction.Y < 0) return;
        //Erase old position
        Move(direction);
    }

    bool IsValidInput(ConsoleKey key)
    {
        return key == ConsoleKey.A || key == ConsoleKey.D || key == ConsoleKey.W || key == ConsoleKey.S ||
               key == ConsoleKey.Spacebar;
    }
    
    public Position GetPlayerDirection()
    {
        var input = Console.ReadKey(true).Key;
        while (!IsValidInput(input))
        {
            input = Console.ReadKey(true).Key;
        }
            
        return input switch
        {
            ConsoleKey.A => new Position(-1, 0),
            ConsoleKey.D => new Position(1, 0),
            ConsoleKey.W => new Position(0, -1),
            ConsoleKey.S => new Position(0, 1),
            ConsoleKey.Spacebar => new Position(0,0),
            _ => throw new Exception("Invalid input")

        };
    }
    
    
}