using System.Data.SQLite;
using UnicomTIC_Management_System.Models;

public class adminController
{
    public void CreateAdmin(Admin admin, SQLiteConnection conn)
    {
        string insert = "INSERT INTO Admin (Name, Phone_Number, Email) VALUES (@Name, @Phone, @Email)";
        using (var cmd = new SQLiteCommand(insert, conn))
        {
            cmd.Parameters.AddWithValue("@Name", admin.Name);
            cmd.Parameters.AddWithValue("@Phone", admin.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", admin.Email);
            cmd.ExecuteNonQuery();
        }
    }
}
