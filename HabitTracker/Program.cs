using HabitTracker.Database;

namespace HabitTracker;

internal static class Program
{
    public static void Main(string[] args)
    {
        Db.CreateDatabase();
        Console.ReadLine();
    }
}
