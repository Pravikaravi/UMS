using System;
using System.Data.SQLite;

namespace UnicomTIC_Management_System.Repositories
{
    public static class DatabaseInitializer
    {
        public static void CreateTables()
        {
            using (var conn = DBConfig.GetConnection())
            {
                // Create Users table
                string createUserTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );";
                SQLiteCommand cmd = new SQLiteCommand(createUserTableQuery, conn);
                cmd.ExecuteNonQuery();


                // Create Students table
                string createStudentTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        UT_Number TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL
                    );";
                cmd = new SQLiteCommand(createStudentTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Create SignupRequests table
                string createSignupRequestsQuery = @"
                    CREATE TABLE IF NOT EXISTS SignupRequests (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        UT_Number TEXT UNIQUE NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Request_Date DATETIME DEFAULT CURRENT_TIMESTAMP
                    );";
                cmd = new SQLiteCommand(createSignupRequestsQuery, conn);
                cmd.ExecuteNonQuery();

                /// Create Staff table
                string createStaffTable = @"
                    CREATE TABLE IF NOT EXISTS Staff (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL
                    );";
                cmd = new SQLiteCommand(createStaffTable, conn);
                cmd.ExecuteNonQuery();

                // Create Admin table
                string createAdminTable = @"
                    CREATE TABLE IF NOT EXISTS Admin (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL
                    );";
                cmd = new SQLiteCommand(createAdminTable, conn);
                cmd.ExecuteNonQuery();

                // Create Lecturer table
                string createLecturerTable = @"
                    CREATE TABLE IF NOT EXISTS Lecturer (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL
                    );";
                cmd = new SQLiteCommand(createLecturerTable, conn);
                cmd.ExecuteNonQuery();

                // Create Course table
                string createCourseTable = @"
                    CREATE TABLE IF NOT EXISTS Course (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL,
                        Duration TEXT NOT NULL,
                        Description TEXT NOT NULL
                    );";
                cmd = new SQLiteCommand(createCourseTable, conn);
                cmd.ExecuteNonQuery();



                // 🆕 Check if Admin exists
                string checkAdminQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'Admin'";
                cmd = new SQLiteCommand(checkAdminQuery, conn);
                long adminCount = (long)cmd.ExecuteScalar();

                if (adminCount == 0)
                {
                    // Insert default admin
                    string insertAdminQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
                    cmd = new SQLiteCommand(insertAdminQuery, conn);
                    cmd.Parameters.AddWithValue("@username", "admin");
                    cmd.Parameters.AddWithValue("@password", "admin123");
                    cmd.Parameters.AddWithValue("@role", "Admin");
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}
