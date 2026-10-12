namespace RougeLike.Models;

/// <summary>
/// Samlar meddelanden från en omgång och skriver ut dem under banan.
/// </summary>
public class MessageLog
{
    private const int MaxLines = 4;
    private readonly List<(string Text, ConsoleColor Color)> _messages = [];

    public void Add(string text, ConsoleColor color = ConsoleColor.White) => _messages.Add((text, color));

    public void Clear() => _messages.Clear();

    public void Draw(int top)
    {
        int width = Math.Max(1, Console.WindowWidth - 1);
        var lines = _messages.TakeLast(MaxLines).ToList();
        for (int i = 0; i < MaxLines; i++)
        {
            Console.SetCursorPosition(0, top + i);
            string text = i < lines.Count ? lines[i].Text : "";
            Console.ForegroundColor = i < lines.Count ? lines[i].Color : ConsoleColor.White;
            Console.Write(text.Length > width ? text[..width] : text.PadRight(width));
            Console.ResetColor();
        }
    }
}
