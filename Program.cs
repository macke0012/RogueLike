using RougeLike.Models;

namespace RougeLike;

class Program
{
    static LevelData levelData = new LevelData();

    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }


}
