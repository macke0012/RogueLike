using RougeLike.Models;
using RougeLike.Models.Enemies;

namespace RougeLike;

public class Game
{
    Player player => LevelData.Elements.OfType<Player>().First();
    

    public void Start()
    {
        LevelData.Load($"{Environment.CurrentDirectory}/map.txt");
        Console.Clear();
        Console.CursorVisible = false;
        LevelData.Elements.ForEach(e => e.Draw());
        Loop();
    }
    
    private void Loop()
    {
        while (true)
        {
            player.Update();
            //Kollar ifall det finns ett element i riktningen som man försöker gå till
            foreach (LevelElement element in LevelData.Elements)
            {
                element.Update();
            }
        }
        
    }

   
}