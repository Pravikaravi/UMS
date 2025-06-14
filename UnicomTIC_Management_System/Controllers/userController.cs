using System.Data.SQLite;
using UnicomTIC_Management_System.Models;

public class userController
{
    public void CreateUser(User user, SQLiteConnection conn)
    {
        string insertUser = @"INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
        using (var cmd = new SQLiteCommand(insertUser, conn))
        {
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.ExecuteNonQuery();
        }
    }
}