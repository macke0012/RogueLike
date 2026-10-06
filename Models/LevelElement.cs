namespace RougeLike.Models;

public record struct Position(int x, int y)
{
    public int X = x;
    public int Y = y;
    
    public static Position operator +(Position a, Position b) => new Position(a.x + b.x, a.y + b.y);
}

public abstract class LevelElement(int x, int y, char symbol, ConsoleColor color)
{
    public Position Position = new Position(x, y);
    public char Symbol = symbol;
    public ConsoleColor CharColor = color;
    private bool _isVisible = false;

    
    /// <summary>
    /// Draws the element to the console if visible, otherwise draws empty space.
    /// </summary>
    public void Draw()
    {
        
        Console.SetCursorPosition(Position.x,Position.y);
        Console.ForegroundColor = CharColor;
        if(_isVisible) Console.Write(Symbol);
        else Console.Write(" ");
        Console.ResetColor();
    }

    public void Move(Position direction)
    {
        Hide();
        Draw();
        Position += direction;
        Show();
        Draw();
    }

    public bool WillCollide(Position direction, List<LevelElement> elements)
    {
        return elements.Any(e => e.Position == Position + direction);
    }
    public void Hide() => _isVisible = false;
    public void Show() => _isVisible = true;
}