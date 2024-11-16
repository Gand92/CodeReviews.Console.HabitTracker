using System.Globalization;

namespace HabitTracker;

public record Habit(int Id, string Name, int Quantity, DateTime CreatedAt)
{
    public override string ToString()
    {
        return $"{Id, -5} {Name, -15} {Quantity, -4} {CreatedAt.ToString("d", CultureInfo.InvariantCulture), -10}";
    }
}
