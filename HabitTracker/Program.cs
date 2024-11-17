using System.Globalization;

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
        DisplayHabitsList();
        Menu();
    }

    private static void DisplayHabitsList()
    {
        Console.WriteLine("List of tracked habits:\n");
        var habits = Db.GetHabits();
        foreach (var habit in habits)
        {
            Console.WriteLine(habit.ToString());
        }
        Console.WriteLine();
    }

    private static void AddHabit()
    {
        Console.WriteLine("Enter the name of the habit: ");
        string name = GetInputString();

        Console.WriteLine("Enter the quantity of the habit: ");
        var quantity = GetInputInt();

        Console.WriteLine("Enter the date of creation (MM/dd/yyyy): ");
        DateTime createdAt = GetInputDate();

        var habit = new Habit(0, name, quantity, createdAt);
        Db.AddHabit(habit);
        DisplayHabitsList();
        Menu();
    }

    private static void RemoveHabit()
    {
        Console.WriteLine("Enter the ID of the habit you want to remove:\n");
        DisplayHabitsList();
        var id = GetInputInt();
        Db.RemoveHabit(id);
        DisplayHabitsList();
        Menu();
    }

    private static void UpdateHabit()
    {
        Console.WriteLine("Enter the ID of the habit you want to update:\n");
        DisplayHabitsList();
        var id = GetInputInt();
        if (!Db.CheckHabitExists(id))
        {
            Console.WriteLine("Habit not found. Try again!\n");
            Menu();
            return;
        }

        Console.WriteLine("Enter the name of the habit: ");
        string name = GetInputString();

        Console.WriteLine("Enter the quantity of the habit: ");
        var quantity = GetInputInt();

        Console.WriteLine("Enter the date of creation (MM/dd/yyyy): ");
        DateTime createdAt = GetInputDate();

        var habit = new Habit(id, name, quantity, createdAt);
        Db.UpdateHabit(habit);
        DisplayHabitsList();
        Menu();
    }

    private static string GetInputString()
    {
        var name = Console.ReadLine() ?? string.Empty;
        while (!ValidationUtilities.IsValidString(name))
        {
            Console.WriteLine("Invalid name. Please enter a valid name: ");
            name = Console.ReadLine() ?? string.Empty;
        }

        return name;
    }

    private static int GetInputInt()
    {
        var quantity = Console.ReadLine() ?? string.Empty;
        while (!ValidationUtilities.IsValidInt(quantity))
        {
            Console.WriteLine("Invalid integer. Please enter a valid quantity: ");
            quantity = Console.ReadLine() ?? string.Empty;
        }

        return Convert.ToInt32(quantity);
    }

    private static DateTime GetInputDate()
    {
        var createdAt = Console.ReadLine() ?? string.Empty;
        while (!ValidationUtilities.IsValidDate(createdAt))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date (MM/dd/yyyy): ");
            createdAt = Console.ReadLine() ?? string.Empty;
        }

        return DateTime.ParseExact(createdAt, "d", CultureInfo.InvariantCulture);
    }
}
