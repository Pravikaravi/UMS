using System.Data.SQLite;
using UnicomTIC_Management_System.Models;

public class staffController
{
    public void CreateStaff(Staff staff, SQLiteConnection conn)
    {
        string insert = "INSERT INTO Staff (Name, Phone_Number, Email) VALUES (@Name, @Phone, @Email)";
        using (var cmd = new SQLiteCommand(insert, conn))
        {
            cmd.Parameters.AddWithValue("@Name", staff.Name);
            cmd.Parameters.AddWithValue("@Phone", staff.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", staff.Email);
            cmd.ExecuteNonQuery();
        }
    }
}
