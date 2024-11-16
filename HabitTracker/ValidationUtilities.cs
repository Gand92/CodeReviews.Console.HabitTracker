using System.Globalization;

namespace HabitTracker;

public static class ValidationUtilities
{
    public static bool IsValidDate(string? createdAt)
    {
        return DateTime.TryParseExact(
            createdAt,
            "d",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out _
        );
    }
}
