using System.Data;
using System.Data.SQLite;
using UnicomTIC_Management_System.Models;
using UnicomTIC_Management_System.Repositories;

public class studentController
{
    public void CreateStudent(Student student, SQLiteConnection conn)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Students (Name, UT_Number, Phone_Number, Email) VALUES (@name, @ut, @phone, @email)";
        cmd.Parameters.AddWithValue("@name", student.Name);
        cmd.Parameters.AddWithValue("@ut", student.UT_Number);
        cmd.Parameters.AddWithValue("@phone", student.Phone_Number);
        cmd.Parameters.AddWithValue("@email", student.Email);
        cmd.ExecuteNonQuery();
    }

    public DataTable GetAllStudents(SQLiteConnection conn)
    {
        DataTable dt = new DataTable();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Students";
        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
        adapter.Fill(dt);
        return dt;
    }

    public void UpdateStudent(Student student, SQLiteConnection conn)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "UPDATE Students SET Name = @name, Phone_Number = @phone, Email = @email WHERE Id = @id";
        cmd.Parameters.AddWithValue("@name", student.Name);
        cmd.Parameters.AddWithValue("@phone", student.Phone_Number);
        cmd.Parameters.AddWithValue("@email", student.Email);
        cmd.Parameters.AddWithValue("@id", student.Id);
        cmd.ExecuteNonQuery();
    }

    public void DeleteStudent(int id, SQLiteConnection conn)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Students WHERE Id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
