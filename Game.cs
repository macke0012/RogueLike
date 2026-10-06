using RougeLike.Models;

namespace RougeLike;

public class Game
{
    LevelData levelData = new LevelData();
    Player player => levelData.Elements.OfType<Player>().First();

    public void Start()
    {
        levelData.Load($"{Environment.CurrentDirectory}/map.txt");
        Console.Clear();
        Console.CursorVisible = false;
        levelData.Elements.ForEach(e => e.Draw());
        Loop();
    }
    
    private void Loop()
    {
        while (true)
        {
            player.Update(levelData.Elements);
            //Kollar ifall det finns ett element i riktningen som man försöker gå till
            
        }
        
    }

   
}