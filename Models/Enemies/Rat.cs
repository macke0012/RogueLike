namespace RougeLike.Models.Enemies;

public class Rat : Enemy
{
    public override string Name => "Rat";
    public override Dice AttackDice { get; } = new(1, 6, 3);
    public override Dice DefenceDice { get; } = new(1, 6, 1);

    public Rat(int x, int y) : base(x, y, 'r', ConsoleColor.Red)
    {
        HP = 10;
    }

    // Rat rör sig ett steg i slumpmässig riktning varje omgång.
    public override void Update(LevelData level, Player player, MessageLog log)
    {
        Position direction = Position.Directions[Random.Shared.Next(Position.Directions.Length)];
        TryMove(direction, level, player, log);
    }
}
