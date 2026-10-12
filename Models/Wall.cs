namespace RougeLike.Models;

public class Wall(int x, int y) : LevelElement(x, y, '#', ConsoleColor.Gray)
{
    // En vägg försvinner aldrig när spelaren väl har sett den.
    public bool IsDiscovered { get; set; }
}
