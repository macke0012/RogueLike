using RougeLike.Models.Enemies;

namespace RougeLike.Models;

public class LevelData
{
    private readonly List<LevelElement> _elements = [];

    //Kan inte exponera det privata fältet och använda readonly samtidigt.
    public List<LevelElement> Elements => _elements;
    

    public void Load(string path)
    {
        string[] lines = File.ReadAllLines(path);
        for(int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                char symbol = lines[y][x];
                
                LevelElement? element = null;
                switch (symbol)
                {
                    case '@':
                        element = new Player(x, y, symbol);
                        break;
                    case 'S':
                        element = new Snake(x, y,symbol,  10, "Snake");
                        break;
                    case 'R':
                        element = new Rat(x, y, symbol, 5, "Rat");
                        break;
                    case '|' or '-':
                        element = new Wall(x, y, symbol);
                        break;
                    
                    
                   
                }
                
                if(element != null)
                {
                    element.Show();
                    _elements.Add(element);
                }
            }
        }
    }
}