namespace HabitTracker;

internal static class Program
{
    public static void Main(string[] args)
    {
        Db.SetupDatabase();
        Menu();
    }

    private static void Menu()
    {
        DisplayMenu();
        ChooseOption();
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\n\nWelcome to your Habit Tracker\n");
        Console.WriteLine("1. Show Habits");
        Console.WriteLine("2. Add Habit");
        Console.WriteLine("3. Remove Habit");
        Console.WriteLine("4. Update Habit");
        Console.WriteLine("5. Exit");
    }

    private static void ChooseOption()
    {
        Console.Write("\nChoose an option from 1 to 5: ");
        var option = Console.ReadLine();
        Console.WriteLine();
        switch (option)
        {
            case "1":
                ShowHabits();
                break;
            case "2":
                AddHabit();
                break;
            case "3":
                RemoveHabit();
                break;
            case "4":
                UpdateHabit();
                break;
            case "5":
                Console.WriteLine("Exit");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine($"Oops! '{option}' is not a valid option. Try again.");
                Menu();
                break;
        }
    }

    private static void ShowHabits()
    {
        Console.WriteLine("List of tracked habits:\n");
        var habits = Db.GetHabits();
        foreach (var habit in habits)
        {
            Console.WriteLine(habit.ToString());
        }
    }

    private static void AddHabit()
    {
        Console.Write("Enter the name of the habit: ");
    }

    private static void RemoveHabit()
    {
        Console.Write("Enter the ID of the habit you want to remove: ");
    }

    private static void UpdateHabit()
    {
        Console.Write("Enter the ID of the habit you want to update: ");
    }
}
