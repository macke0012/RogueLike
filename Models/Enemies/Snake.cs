namespace RougeLike.Models.Enemies;

public class Snake : Enemy
{
    private const int FleeDistance = 2;

    public override string Name => "Snake";
    public override Dice AttackDice { get; } = new(3, 4, 2);
    public override Dice DefenceDice { get; } = new(1, 8, 5);

    public Snake(int x, int y) : base(x, y, 's', ConsoleColor.Green)
    {
        HP = 25;
    }

    // Snake står still om spelaren är mer än 2 rutor bort, annars flyttar den sig bort från spelaren.
    public override void Update(LevelData level, Player player, MessageLog log)
    {
        double currentDistance = Position.DistanceTo(player.Position);
        if (currentDistance > FleeDistance) return;

        // Välj den lediga riktning som ökar avståndet till spelaren mest.
        Position? best = Position.Directions
            .Select(d => (Direction: d, Target: Position + d))
            .Where(t => t.Target != player.Position && level.GetElementAt(t.Target) is null)
            .Select(t => (t.Direction, Distance: t.Target.DistanceTo(player.Position)))
            .Where(t => t.Distance > currentDistance)
            .OrderByDescending(t => t.Distance)
            .Select(t => (Position?)t.Direction)
            .FirstOrDefault();

        if (best is { } direction)
        {
            TryMove(direction, level, player, log);
        }
    }
}
