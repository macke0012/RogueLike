namespace RougeLike.Models;

public class Renderer
{
    // Which walls the player has already discovered.
    // Walls stay visible once seen, enemies only while in range.

    // One line on the dashboard: a label and a function that produces the current value.
    private record DashboardItem(string Label, Func<string> GetValue, ConsoleColor Color);

    private readonly List<DashboardItem> _dashboardItems = [];
    private int _dashboardTop;
    private int _dashboardWidth;

    public void DrawAll(LevelData data) => throw new NotImplementedException();

    // Redraw what changed after a turn, applying the vision rules.
    public void Refresh(LevelData data) => throw new NotImplementedException();

    public void DrawStatus(Player player) => throw new NotImplementedException(); // HP etc.

    public void DrawElement(LevelElement element)
    {

    }

    /// <summary>
    /// Places the dashboard right below the map. Call after the level is loaded.
    /// </summary>
    public void PlaceDashboard(LevelData data)
    {
        _dashboardTop = data.Elements.Max(element => element.Position.Y) + 2;
        _dashboardWidth = Math.Max(data.Elements.Max(element => element.Position.X) + 1, 40);
    }

    /// <summary>
    /// Adds a line to the dashboard. The value is read again every time the dashboard is drawn.
    /// </summary>
    public void AddDashboardItem(string label, Func<string> getValue, ConsoleColor color = ConsoleColor.White)
    {
        _dashboardItems.Add(new DashboardItem(label, getValue, color));
    }

    public void ClearDashboardItems() => _dashboardItems.Clear();

    public void DrawDashboard()
    {
        Console.SetCursorPosition(0, _dashboardTop);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(new string('─', _dashboardWidth));

        int labelWidth = _dashboardItems.Count == 0 ? 0 : _dashboardItems.Max(item => item.Label.Length);

        for (int i = 0; i < _dashboardItems.Count; i++)
        {
            DashboardItem item = _dashboardItems[i];
            Console.SetCursorPosition(0, _dashboardTop + 1 + i);

            Console.ForegroundColor = item.Color;
            string label = $"{item.Label.PadRight(labelWidth)} : ";
            Console.Write(label);

            Console.ForegroundColor = ConsoleColor.Gray;
            // Pad so a shorter value overwrites what was printed last turn.
            Console.Write(item.GetValue().PadRight(_dashboardWidth - label.Length));
        }

        Console.ResetColor();
    }
}
