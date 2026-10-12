namespace RougeLike.Models;

/// <summary>
/// Gemensamt för allt som kan slåss: spelaren och fiender.
/// </summary>
public interface ICombatant
{
    string Name { get; }
    int HP { get; set; }
    Dice AttackDice { get; }
    Dice DefenceDice { get; }
    bool IsAlive { get; }
}
