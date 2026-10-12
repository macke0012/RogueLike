using RougeLike.Models;
using RougeLike.Models.Enemies;

namespace RougeLike;

public class Game
{
    private readonly LevelData _level = new();
    private readonly MessageLog _log = new();
    private Player _player = null!;
    private int _turn;

    // Positioner där en fiende/spelaren ritades förra omgången, så att de kan suddas ut.
    private readonly List<Position> _drawnLastTurn = [];

    public void Start(string levelFile)
    {
        _level.Load(levelFile);
        _player = new Player(_level.PlayerStartPosition.X, _level.PlayerStartPosition.Y);

        Console.Clear();
        Console.CursorVisible = false;
        _log.Add("Welcome! Move with arrow keys / WASD, Space to wait, Esc to quit.", ConsoleColor.Cyan);

        try
        {
            Loop();
        }
        finally
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, _level.Height + 6);
        }
    }

    private void Loop()
    {
        Render();
        while (_player.IsAlive)
        {
            Position? direction = ReadInput();
            if (direction is null) return; // Esc

            _log.Clear();
            _turn++;

            // Spelarens drag
            _player.Move(direction.Value, _level, _log);
            RemoveDeadEnemies();

            // Datorns drag
            foreach (Enemy enemy in _level.Elements.OfType<Enemy>().ToList())
            {
                if (!enemy.IsAlive) continue;
                enemy.Update(_level, _player, _log);
                if (!_player.IsAlive) break;
            }
            RemoveDeadEnemies();

            Render();
        }

        _log.Add("You died. GAME OVER! Press any key to exit.", ConsoleColor.DarkRed);
        Render();
        Console.ReadKey(true);
    }

    private static Position? ReadInput()
    {
        while (true)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow or ConsoleKey.W: return Position.Up;
                case ConsoleKey.DownArrow or ConsoleKey.S: return Position.Down;
                case ConsoleKey.LeftArrow or ConsoleKey.A: return Position.Left;
                case ConsoleKey.RightArrow or ConsoleKey.D: return Position.Right;
                case ConsoleKey.Spacebar: return Position.None;
                case ConsoleKey.Escape: return null;
            }
        }
    }

    private void RemoveDeadEnemies()
    {
        foreach (Enemy dead in _level.Elements.OfType<Enemy>().Where(e => !e.IsAlive).ToList())
        {
            _level.Remove(dead);
        }
    }

    private void Render()
    {
        foreach (Position position in _drawnLastTurn)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(' ');
        }
        _drawnLastTurn.Clear();

        foreach (LevelElement element in _level.Elements)
        {
            bool inSight = _player.CanSee(element);
            if (element is Wall wall)
            {
                if (inSight) wall.IsDiscovered = true;
                if (wall.IsDiscovered) wall.Draw();
            }
            else if (inSight)
            {
                // Fiender syns bara inom synfältet (men uppdateras ändå varje omgång).
                element.Draw();
                _drawnLastTurn.Add(element.Position);
            }
        }

        _player.Draw();
        _drawnLastTurn.Add(_player.Position);

        DrawStatus();
        _log.Draw(_level.Height + 2);
    }

    private void DrawStatus()
    {
        Console.SetCursorPosition(0, _level.Height + 1);
        Console.ForegroundColor = ConsoleColor.White;
        string status = $"{_player.Name}  HP: {_player.HP}/100  Attack: {_player.AttackDice}  " +
                        $"Defence: {_player.DefenceDice}  Turn: {_turn}";
        Console.Write(status.PadRight(Math.Max(status.Length, Console.WindowWidth - 1)));
        Console.ResetColor();
    }
}
