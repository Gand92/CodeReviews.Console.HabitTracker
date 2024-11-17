using System.Globalization;

namespace HabitTracker;

public static class ValidationUtilities
{
    public static bool IsValidString(string? name)
    {
        return !string.IsNullOrWhiteSpace(name) && !name.Any(char.IsDigit);
    }

    public static bool IsValidInt(string? quantity)
    {
        return int.TryParse(quantity, out int result) && result > 0;
    }

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
