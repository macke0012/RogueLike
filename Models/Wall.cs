using System.Runtime.CompilerServices;

namespace RougeLike.Models;

public class Wall(int x, int y, char symbol) : LevelElement(x, y, symbol, ConsoleColor.DarkGray)
{
    public bool Seen { get; private set; } = false;

    public void FlagAsSeen()
    {
        Seen = true;
    }

}