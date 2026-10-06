using System.Runtime.CompilerServices;

namespace RougeLike.Models;

public class Wall(int x, int y, char symbol) : LevelElement(x, y, symbol, ConsoleColor.DarkGray)
{
    
}