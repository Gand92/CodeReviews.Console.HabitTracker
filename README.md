# Habit Tracker CRUD App

## Stack and Technologies

- **Application Type**: Console Application  
- **Language**: C#  
- **Database**: SQLite  
- **Database Interaction**: ADO.NET  
- **Tools**: Optional use of [SQLite DB Browser](https://sqlitebrowser.org/) for database inspection  

---

## Introduction

This project is a simple application designed to practice CRUD (Create, Read, Update, Delete) operations with a real database. CRUD forms the foundation of web development, making it a vital skill to master early on. The app uses basic SQL commands and **ADO.NET**, providing a closer understanding of database interactions while building a full-stack application.

## Features

- Tracks habits based on quantity (e.g., glasses of water) rather than time.
- Logs the date of each habit occurrence.
- Automatically initializes a SQLite database and table on the first run.
- Full CRUD functionality:
  - **Create**: Add new entries.
  - **Read**: View logged habits.
  - **Update**: Modify entries.
  - **Delete**: Remove logs.
- Includes error handling to prevent crashes and follows the **DRY Principle** for cleaner code.

## Skills and Concepts Highlighted

This project enhances:

- SQL command usage and ADO.NET database interactions.
- Error handling and input validation.
- Development principles like **KISS** (Keep It Simple, Stupid) and **DRY**.
- Secure database queries using parameterized statements.

## How It Works

1. On launch, the app creates a database and table if needed.
2. A menu allows users to:
   - Log a new habit.
   - View, update, or delete existing logs.
3. User input is validated to ensure the app handles errors gracefully (e.g., invalid dates or menu choices).

## Potential Extensions

- Add custom habits and measurement units.
- Seed sample data into the database for testing.
- Generate reports (e.g., yearly totals or statistics).

---

The Habit Tracker CRUD App provides hands-on experience with database operations, helping to build essential skills for full-stack development while emphasizing simplicity and functionality.
