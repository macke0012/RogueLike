namespace RougeLike.Models;

public class Player(int x, int y) : LevelElement(x, y, '@', ConsoleColor.Yellow), ICombatant
{
    public const int VisionRange = 5;

    public string Name => "Player";
    public int HP { get; set; } = 100;
    public Dice AttackDice { get; } = new(2, 6, 2);
    public Dice DefenceDice { get; } = new(2, 6, 0);
    public bool IsAlive => HP > 0;

    public bool CanSee(LevelElement element) => Position.DistanceTo(element.Position) <= VisionRange;

    /// <summary>
    /// Flyttar spelaren ett steg i given riktning. Står en fiende i vägen attackeras den,
    /// står en vägg i vägen avbryts förflyttningen.
    /// </summary>
    public void Move(Position direction, LevelData level, MessageLog log)
    {
        if (direction == Position.None) return;

        Position target = Position + direction;
        switch (level.GetElementAt(target))
        {
            case Enemies.Enemy enemy:
                Combat.Fight(this, enemy, log);
                break;
            case null:
                Position = target;
                break;
            // Vägg: förflyttningen avbryts
        }
    }
}
