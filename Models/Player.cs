namespace RougeLike.Models;



public class Player(int x, int y, char symbol) : LevelElement(x, y, symbol, ConsoleColor.Magenta)
{
    public void Update(List<LevelElement> elements)
    {
        Position direction = new()
        {
            X = 0,
            Y = 0
        };
        do
        {
            direction = GetPlayerDirection();
            if (!WillCollide(direction, elements)) break;

        } while (true);




        if (Position.X + direction.X < 0 || Position.Y + direction.Y < 0) return;
        //Erase old position
        Move(direction);



    }

    public void UpdateVisibility(List<LevelElement> elements, int radius = 5)
    {
        foreach (var element in elements)
        {
            if (element == this)
            {
                element.Show();
                continue;
            }
            if (element.GetDistanceSquaredToPlayer(this) <= radius * radius)
            {

                element.Show();
            }
            else
            {

                element.Hide();
            }
        }
    }



    bool IsValidInput(ConsoleKey key)
    {
        return key == ConsoleKey.A || key == ConsoleKey.D || key == ConsoleKey.W || key == ConsoleKey.S ||
               key == ConsoleKey.Spacebar;
    }

    public Position GetPlayerDirection()
    {
        ConsoleKey input;


        input = Console.ReadKey(true).Key;


        while (!IsValidInput(input))
        {


            input = Console.ReadKey(true).Key;

        }

        return input switch
        {
            ConsoleKey.A => new Position()
            {
                X = -1,
                Y = 0
            },
            ConsoleKey.D => new Position()
            {
                X = 1,
                Y = 0
            },
            ConsoleKey.W => new Position()
            {
                X = 0,
                Y = -1
            },
            ConsoleKey.S => new Position()
            {
                X = 0,
                Y = 1
            },
            ConsoleKey.Spacebar => new Position()
            {
                X = 0,
                Y = 0
            },
            _ => throw new Exception("Invalid input")

        };
    }


}