using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management_System.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
