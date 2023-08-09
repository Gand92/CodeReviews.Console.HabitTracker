﻿using Microsoft.Data.Sqlite;

class HabitTracker {
     private static void Main(string[] args) {

          HabitTracker DrinkingWater = new HabitTracker();

          DrinkingWater.InitiateDataBase();
          DrinkingWater.MainMenu();

     }
     
     void InitiateDataBase() {

          string connectionString = @"Data Source=HabitTracker.db";

          using (var connection = new SqliteConnection(connectionString)) {

               connection.Open();

               var tableCmd = connection.CreateCommand();

               tableCmd.CommandText =
                         @"CREATE TABLE IF NOT EXISTS drinking_water (
                         Id INTEGER PRIMARY KEY AUTOINCREMENT,
                         Date TEXT,
                         Quantity INTEGER
                         )";

               tableCmd.ExecuteNonQuery();

               connection.Close();
          }
     }

     void MainMenu() {

          Console.WriteLine("WELCOME TO HABIT TRACKER\n");

          Console.WriteLine("\tMAIN MENU\n");

          Console.WriteLine("Type 0 to Close Application.");
          Console.WriteLine("Type 1 to View All Records.");
          Console.WriteLine("Type 2 to Insert Record.");
          Console.WriteLine("Type 3 to Delete Record.");
          Console.WriteLine("Type 4 to Update Record.");
          
          string UserOption = Console.ReadLine();

          Console.Clear();

          InputCheck(UserOption);
     }

     void InputCheck(string UserOption) {

          if(string.IsNullOrEmpty(UserOption) || Convert.ToInt32(UserOption) < 0 || Convert.ToInt32(UserOption) > 4) {
               Console.WriteLine("Please select one of the options\n");
               MainMenu();
          }

          switch (Convert.ToInt32(UserOption)) {

               case 0:
                    Console.WriteLine("Good Bye");
                    System.Environment.Exit(0);
                    break;
               case 1:
                    Console.WriteLine("Gathering ALL Records");
                    ViewRecords();
                    break;
               case 2:
                    Console.WriteLine("Inserting Racord");
                    InsertRecord();
                    break;
               case 3:
                    Console.WriteLine("Deleting Record");
                    DeleteRecord();
                    break;
               case 4:
                    Console.WriteLine("Updating Record");
                    UpdateRecord();
                    break;
               default:
                    Console.WriteLine("Please select one of the options");
                    MainMenu();
                    break;
          }
     }

     
     void ViewRecords() {

          string connectionString = @"Data Source=HabitTracker.db";

          using (var connection = new SqliteConnection(connectionString)) {
               connection.Open();
               using (SqliteCommand command = new SqliteCommand($"SELECT * FROM drinking_water", connection)) {
                    // Execute the command and read til end of file
                    using (SqliteDataReader reader = command.ExecuteReader()) {
                         while (reader.Read()) {
                              Console.WriteLine($"Id: {reader["Id"]}, Date: {reader["Date"]}, Quantity: {reader["Quantity"]}");
                         }
                    }
               }
          }
          ReturnToMenu();
     }
     
     void InsertRecord() {
          Console.Clear();

          Console.WriteLine("Please Enter Todays Date (MM/DD/YYYY)");
          string Date = Console.ReadLine();
          Console.WriteLine("Please Enter how many cups you drank today");
          int Num_Cups = Convert.ToInt32(Console.ReadLine());

          string connectionString = @"Data Source=HabitTracker.db";

          using (var connection = new SqliteConnection(connectionString)) {
               connection.Open();

               string query = "INSERT INTO drinking_water (Date, Quantity) VALUES (@Date, @Quantity)";
               using (SqliteCommand command = new SqliteCommand(query, connection)) {
                    // Adding parameters for the date and quantity
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@Quantity", Num_Cups);

                    command.ExecuteNonQuery();
               }

               connection.Close();
               Console.WriteLine("Data Successfully Inserted");
               ReturnToMenu();
          }
     }
     
     void DeleteRecord() {





          ReturnToMenu();
     }
     
     void UpdateRecord() {



          ReturnToMenu();
     }

     void ReturnToMenu() {
          Console.WriteLine("\nEnter Anything for Main Menu");
          string UserInput = Console.ReadLine();
          Console.Clear();
          if (string.IsNullOrEmpty(UserInput) || !string.IsNullOrEmpty(UserInput))
          {
               MainMenu();
          }
     }
}