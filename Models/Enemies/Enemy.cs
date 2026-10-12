namespace RougeLike.Models.Enemies;

public abstract class Enemy(int x, int y, char symbol, ConsoleColor color) : LevelElement(x, y, symbol, color), ICombatant
{
    public abstract string Name { get; }
    public int HP { get; set; }
    public abstract Dice AttackDice { get; }
    public abstract Dice DefenceDice { get; }
    public bool IsAlive => HP > 0;

    /// <summary>
    /// Anropas en gång per omgång. Varje typ av fiende bestämmer själv hur den rör sig.
    /// </summary>
    public abstract void Update(LevelData level, Player player, MessageLog log);

    /// <summary>
    /// Försöker flytta fienden ett steg. Står spelaren där attackeras spelaren,
    /// står en vägg eller annan fiende där avbryts förflyttningen.
    /// </summary>
    protected void TryMove(Position direction, LevelData level, Player player, MessageLog log)
    {
        if (direction == Position.None) return;

        Position target = Position + direction;
        if (target == player.Position)
        {
            Combat.Fight(this, player, log);
        }
        else if (level.GetElementAt(target) is null)
        {
            Position = target;
        }
    }
}
