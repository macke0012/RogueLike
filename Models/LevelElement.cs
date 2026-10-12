namespace RougeLike.Models;

public abstract class LevelElement(int x, int y, char symbol, ConsoleColor color)
{
    public Position Position { get; set; } = new(x, y);
    public int X => Position.X;
    public int Y => Position.Y;
    public char Symbol { get; } = symbol;
    public ConsoleColor Color { get; } = color;

    /// <summary>
    /// Ritar ut elementet med rätt tecken och färg på rätt plats.
    /// </summary>
    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.ForegroundColor = Color;
        Console.Write(Symbol);
        Console.ResetColor();
    }

}
