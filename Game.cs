using RougeLike.Models;
using RougeLike.Models.Enemies;

namespace RougeLike;

public class Game
{
    LevelData LevelData = new();
    Player player => LevelData.Elements.OfType<Player>().First();
    Renderer Renderer = new();
    int turn = 0;


    public void Start()
    {
        LevelData.Load($"{Environment.CurrentDirectory}/Level1.txt");
        Console.Clear();
        Console.CursorVisible = false;
        player.UpdateVisibility(LevelData.Elements);

        SetupDashboard();
        Renderer.DrawDashboard();

        Loop();
    }

    private void Loop()
    {
        while (true)
        {
            player.Update(LevelData.Elements);

            foreach (Enemy element in LevelData.Elements.OfType<Enemy>())
            {

                element.Update(LevelData.Elements);
            }
            player.UpdateVisibility(LevelData.Elements);

            turn++;
            Renderer.DrawDashboard();
        }

    }

    // Choose what the dashboard shows here: add, remove or reorder lines.
    private void SetupDashboard()
    {
        Renderer.PlaceDashboard(LevelData);

        Renderer.AddDashboardItem("Turn", () => turn.ToString());
        Renderer.AddDashboardItem("Position", () => $"({player.Position.X}, {player.Position.Y})", ConsoleColor.Magenta);
        Renderer.AddDashboardItem("Enemies nearby", () =>
        {
            var nearby = LevelData.Elements.OfType<Enemy>()
                .Where(enemy => IsInRadius(player, enemy, 5))
                .Select(enemy => $"{enemy.Name} ({enemy.Health} HP)")
                .ToList();
            return nearby.Count == 0 ? "none" : string.Join(", ", nearby);
        }, ConsoleColor.Red);
        Renderer.AddDashboardItem("Enemies left", () => LevelData.Elements.OfType<Enemy>().Count().ToString(), ConsoleColor.Yellow);

    }

    private bool IsInRadius(LevelElement center, LevelElement elementToCheck, int radius)
    {
        int dx = center.Position.X - elementToCheck.Position.X;
        int dy = center.Position.Y - elementToCheck.Position.Y;

        return (dx * dx) + (dy * dy) <= radius * radius;
    }


}