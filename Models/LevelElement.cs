namespace RougeLike.Models;

public record struct Position()
{
    public required int X;
    public required int Y;

    public static Position operator +(Position a, Position b) => new Position()
    {
        X = a.X + b.X,
        Y = a.Y + b.Y
    };
}

public abstract class LevelElement(int x, int y, char symbol, ConsoleColor color)
{
    public Position Position = new Position()
    {
        X = x,
        Y = y
    };
    public char Symbol = symbol;
    public ConsoleColor CharColor = color;

    private bool _isVisible;

    public bool IsVisible
    {
        get => _isVisible;
        private set
        {
            if (_isVisible == value)
            {
                return;
            }

            _isVisible = value;
            Draw();
        }
    }


    /// <summary>
    /// Draws the element to the console if visible, otherwise draws empty space.
    /// </summary>
    public virtual void Draw()
    {

        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = CharColor;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    private void CleanOldPosition()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(" ");
    }




    public void Move(Position direction)
    {
        CleanOldPosition();
        Position += direction;


    }


    public int GetDistanceSquaredToPlayer(Player player)
    {
        int dx = player.Position.X - Position.X;
        int dy = player.Position.Y - Position.Y;
        return dx * dx + dy * dy;
    }


    public bool WillCollide(Position direction, List<LevelElement> elements)
    {
        Position newPosition = Position + direction;
        return elements.Any(element => element.Position == newPosition);

    }

    public void Hide()
    {
        if (this is Wall wall)
        {
            if (wall.Seen)
            {
                return;
            }
        }
        if (this is Player)
        {
            return;
        }
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(" ");
        IsVisible = false;
    }
    public void Show()
    {
        if (this is Wall wall)
        {
            wall.FlagAsSeen();
        }
        IsVisible = true;
        Draw();
    }
}