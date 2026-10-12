namespace RougeLike.Models;

public readonly record struct Position(int X, int Y)
{
    public static readonly Position Up = new(0, -1);
    public static readonly Position Down = new(0, 1);
    public static readonly Position Left = new(-1, 0);
    public static readonly Position Right = new(1, 0);
    public static readonly Position None = new(0, 0);

    public static readonly Position[] Directions = [Up, Down, Left, Right];

    public static Position operator +(Position a, Position b) => new(a.X + b.X, a.Y + b.Y);

    // Pythagoras sats: avståndet mellan två punkter i 2D
    public double DistanceTo(Position other)
    {
        int dx = X - other.X;
        int dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
