namespace RougeLike.Models.Enemies;

public class Snake(int x, int y, char symbol, int health, string name) : Enemy(x, y, symbol, ConsoleColor.DarkGreen, health, name)
{
    public override void Update(List<LevelElement> elements)
    {
        return;
    }
}