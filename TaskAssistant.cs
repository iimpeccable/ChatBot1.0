using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ChatBot1._0GUI
{
    class TaskAssistant
    {
        private readonly string _connectionString;

        public TaskAssistant(string connectionString)
        {
            _connectionString = connectionString;
            EnsureTablesExist();
        }

        private void EnsureTablesExist()
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string createTasks = @"CREATE TABLE IF NOT EXISTS Tasks (
                                    Id INT AUTO_INCREMENT PRIMARY KEY,
                                    Description VARCHAR(255),
                                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                  );";

            string createReminders = @"CREATE TABLE IF NOT EXISTS Reminders (
                                        Id INT AUTO_INCREMENT PRIMARY KEY,
                                        Description VARCHAR(255),
                                        CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                      );";

            using var cmd1 = new MySqlCommand(createTasks, conn);
            cmd1.ExecuteNonQuery();

            using var cmd2 = new MySqlCommand(createReminders, conn);
            cmd2.ExecuteNonQuery();
        }

        /// Add Task
        public void AddTask(string description)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string sql = "INSERT INTO Tasks (Description) VALUES (@desc)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@desc", description);
            cmd.ExecuteNonQuery();
        }

        /// Get Tasks
        public List<string> GetTasks()
        {
            var tasks = new List<string>();
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string sql = "SELECT Description, CreatedAt FROM Tasks ORDER BY CreatedAt DESC LIMIT 10";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add($"{reader["CreatedAt"]}: {reader["Description"]}");
            }

            return tasks;
        }

        /// Add Reminder
        public void AddReminder(string description)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string sql = "INSERT INTO Reminders (Description) VALUES (@desc)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@desc", description);
            cmd.ExecuteNonQuery();
        }

        /// Get Reminders
        public List<string> GetReminders()
        {
            var reminders = new List<string>();
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string sql = "SELECT Description, CreatedAt FROM Reminders ORDER BY CreatedAt DESC LIMIT 10";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reminders.Add($"{reader["CreatedAt"]}: {reader["Description"]}");
            }

            return reminders;
        }
    }
}
