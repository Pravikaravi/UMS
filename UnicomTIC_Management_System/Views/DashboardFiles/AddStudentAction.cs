using System;
using System.Data.SQLite;
using System.Windows.Forms;
using UnicomTIC_Management_System.Controllers;
using UnicomTIC_Management_System.Models;
using UnicomTIC_Management_System.Repositories;

namespace UnicomTIC_Management_System.Views.DashboardFiles
{
    public partial class AddStudentAction : UserControl
    {
        private studentController studentController = new studentController();
        private userController userController = new userController();

        public AddStudentAction()
        {
            InitializeComponent();
            this.Load += AddStudentAction_Load;
        }

        private void AddStudentAction_Load(object sender, EventArgs e)
        {
            // Optional: load logic or form reset
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtUT_Number.Text) ||
                string.IsNullOrWhiteSpace(txtPhone_Number.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill all boxes", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                Name = txtName.Text,
                UT_Number = txtUT_Number.Text,
                Phone_Number = txtPhone_Number.Text,
                Email = txtEmail.Text
            };

            // Create user account
            var user = new User
            {
                Username = txtUT_Number.Text,
                Password = txtPassword.Text, // direct from form
                Role = "Student"
            };

            using (var conn = DBConfig.GetConnection())
            {
                studentController.CreateStudent(student, conn);
                userController.CreateUser(user, conn);
            }

            MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtUT_Number.Clear();
            txtPhone_Number.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }

        // Optional handler if mistakenly wired in designer
        private void btnSignup_Click(object sender, EventArgs e)
        {
            btnAddStudent_Click(sender, e);
        }

        private void AddStudentControl_Load(object sender, EventArgs e)
        {
            // You can leave it empty or initialize something here
        }
    }
}
