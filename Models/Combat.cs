namespace RougeLike.Models;

public static class Combat
{
    /// <summary>
    /// Anfallaren attackerar först; överlever försvararen gör den direkt en motattack.
    /// </summary>
    public static void Fight(ICombatant attacker, ICombatant defender, MessageLog log)
    {
        Attack(attacker, defender, log);
        if (defender.IsAlive)
        {
            Attack(defender, attacker, log);
        }
    }

    private static void Attack(ICombatant attacker, ICombatant defender, MessageLog log)
    {
        int attack = attacker.AttackDice.Throw();
        int defence = defender.DefenceDice.Throw();
        int damage = Math.Max(0, attack - defence);
        defender.HP = Math.Max(0, defender.HP - damage);

        string result = damage switch
        {
            0 => "but it has no effect.",
            _ when !defender.IsAlive => $"dealing {damage} damage and killing it!",
            _ => $"dealing {damage} damage.",
        };

        ConsoleColor color = attacker is Player ? ConsoleColor.Green : ConsoleColor.Red;
        log.Add(
            $"{attacker.Name} ({attacker.AttackDice} => {attack}) attacks {defender.Name} " +
            $"({defender.DefenceDice} => {defence}), {result}",
            color);
    }
}
