using RougeLike.Models.Enemies;

namespace RougeLike.Models;

public class LevelData
{
    private List<LevelElement> elements = [];

    public IReadOnlyList<LevelElement> Elements => elements;
    public Position PlayerStartPosition { get; private set; }
    public int Height { get; private set; }

    /// <summary>
    /// Läser in banan tecken för tecken och skapar ett objekt för varje vägg/fiende.
    /// </summary>
    public void Load(string filename)
    {
        elements = [];
        string[] lines = File.ReadAllLines(filename);
        Height = lines.Length;

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                switch (lines[y][x])
                {
                    case '#':
                        elements.Add(new Wall(x, y));
                        break;
                    case 'r':
                        elements.Add(new Rat(x, y));
                        break;
                    case 's':
                        elements.Add(new Snake(x, y));
                        break;
                    case '@':
                        PlayerStartPosition = new Position(x, y);
                        break;
                }
            }
        }
    }

    public LevelElement? GetElementAt(Position position) => elements.FirstOrDefault(e => e.Position == position);

    public void Remove(LevelElement element) => elements.Remove(element);
}
