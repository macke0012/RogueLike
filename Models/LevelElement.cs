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

    private bool IsVisible
    {
        get => this == LevelData.Player || IsInRadius(5);
        set;
    }


    /// <summary>
    /// Draws the element to the console if visible, otherwise draws empty space.
    /// </summary>
    public void Draw(bool clear = false)
    {
        
        Console.SetCursorPosition(Position.x,Position.y);
        Console.ForegroundColor = CharColor;
        Console.Write(clear ? " " : Symbol);
        
        Console.ResetColor();
    }

    public virtual void Update()
    {
        if(IsVisible) Draw();
        else Draw(true);
    }

    public bool IsInRadius(int radius)
    {
        return GetDistanceToPlayer() <= radius;
    }

    public void Move(Position direction)
    {
        
        Draw(true);
        Position += direction;
        Draw();
    }

    public int GetDistanceToPlayer() => Math.Abs(Position.x - LevelData.Player.Position.x) + Math.Abs(Position.y - LevelData.Player.Position.y);
    

    public bool WillCollide(Position direction)
    {
        return LevelData.Elements.Any(e => e.Position == Position + direction);
    }

}