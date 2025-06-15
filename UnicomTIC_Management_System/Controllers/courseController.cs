using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management_System.Models;

namespace UnicomTIC_Management_System.Controllers
{
    internal class courseController
    {
        public void CreateUser(Course course, SQLiteConnection conn)
        {
            string insertCourse = @"INSERT INTO Course (Name , Duration, Description) VALUES (@Username, @Password, @Role)";
            using (var cmd = new SQLiteCommand(insertCourse, conn))
            {
                cmd.Parameters.AddWithValue("@Username", course.Name);
                cmd.Parameters.AddWithValue("@Duration", course.Duration);
                cmd.Parameters.AddWithValue("@Role", course.Description);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
