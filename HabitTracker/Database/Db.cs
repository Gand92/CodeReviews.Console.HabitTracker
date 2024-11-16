using Microsoft.Data.Sqlite;

namespace HabitTracker.Database;

public static class Db
{
    private const string ConnectionString = @"Data Source=..\..\..\habit-tracker.db";

    public static void CreateDatabase()
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
        Console.WriteLine(error);

        connection.Close();
    }
}
