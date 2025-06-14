using System.Data.SQLite;
using UnicomTIC_Management_System.Models;

public class lecturerController
{
    public void CreateLecturer(Lecturer lecturer, SQLiteConnection conn)
    {
        string insert = "INSERT INTO Lecturer (Name, Phone_Number, Email) VALUES (@Name, @Phone, @Email)";
        using (var cmd = new SQLiteCommand(insert, conn))
        {
            cmd.Parameters.AddWithValue("@Name", lecturer.Name);
            cmd.Parameters.AddWithValue("@Phone", lecturer.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", lecturer.Email);
            cmd.ExecuteNonQuery();
        }
    }
}
