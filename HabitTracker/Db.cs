using System.Globalization;
using Microsoft.Data.Sqlite;

namespace HabitTracker;

public static class Db
{
    private const string ConnectionString = @"Data Source=..\..\..\habit-tracker.db";

    public static void SetupDatabase()
    {
        CreateDatabase();
        PopulateDatabase();
    }

    private static void CreateDatabase()
    {
        using var connection = new SqliteConnection(ConnectionString);

        connection.Open();
        var tableCommand = connection.CreateCommand();
        tableCommand.CommandText =
            @"CREATE TABLE IF NOT EXISTS Habits (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Quantity INTEGER NOT NULL,
            CreatedAt TEXT NOT NULL
        )";
        int error = tableCommand.ExecuteNonQuery();
        if (error != 0)
        {
            Console.WriteLine("Error creating table Habits");
            Console.WriteLine("Exiting...");
            Environment.Exit(1);
        }
        connection.Close();
    }

    private static void PopulateDatabase()
    {
        if (!IsTableEmpty())
        {
            return;
        }

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var insertCommand = connection.CreateCommand();
        insertCommand.CommandText =
            @"
        INSERT INTO Habits (Name, Quantity, CreatedAt)
        VALUES (@Name, @Quantity, @CreatedAt)";

        var random = new Random();
        for (int i = 0; i < 10; i++)
        {
            insertCommand.Parameters.Clear();
            insertCommand.Parameters.AddWithValue("@Name", $"Habit Test{i + 1}");
            insertCommand.Parameters.AddWithValue("@Quantity", random.Next(1, 100));
            insertCommand.Parameters.AddWithValue(
                "@CreatedAt",
                DateTime.Now.ToString("d", CultureInfo.InvariantCulture)
            );

            insertCommand.ExecuteNonQuery();
        }

        connection.Close();
    }

    public static List<Habit> GetHabits()
    {
        var habits = new List<Habit>();
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var selectCommand = connection.CreateCommand();
        selectCommand.CommandText = "SELECT * FROM Habits";

        using var reader = selectCommand.ExecuteReader();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var name = reader.GetString(1);
            var quantity = reader.GetInt32(2);
            var createdAt = reader.GetDateTime(3);
            habits.Add(new Habit(id, name, quantity, createdAt));
        }

        connection.Close();
        return habits;
    }

    public static bool IsTableEmpty()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var selectCommand = connection.CreateCommand();
        selectCommand.CommandText = "SELECT COUNT(*) FROM Habits";

        var count = (long)(selectCommand.ExecuteScalar() ?? throw new InvalidOperationException());

        connection.Close();
        return count == 0;
    }
}
