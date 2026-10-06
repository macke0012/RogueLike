namespace RougeLike.Models.Enemies;

public abstract class Enemy(int x, int y, char symbol, ConsoleColor color, int health, string name) : LevelElement(x, y, symbol, color)
{
    public int Health = health;
    public string Name = name;

    public abstract void Update(List<LevelElement> elements);

    
   
}