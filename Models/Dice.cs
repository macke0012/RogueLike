namespace RougeLike.Models;

public class Dice(int numberOfDice, int sidesPerDice, int modifier)
{
    public int NumberOfDice { get; } = numberOfDice;
    public int SidesPerDice { get; } = sidesPerDice;
    public int Modifier { get; } = modifier;
    
    public override string ToString() => $"{NumberOfDice}d{SidesPerDice}+{Modifier}";

    public int Throw()
    {
        int sum = 0;
        for (int i = 0; i < NumberOfDice; i++)
        {
            sum += Random.Shared.Next(1, SidesPerDice);
        }
        return sum + Modifier;
    }
}