using System;
using System.Windows.Forms;
using UnicomTIC_Management_System.Controllers;
using UnicomTIC_Management_System.Models;
using UnicomTIC_Management_System.Repositories;

namespace UnicomTIC_Management_System.Views.DashboardFiles
{
    public partial class AddUserAction : UserActions
    {
        public AddUserAction()
        {
            InitializeComponent();
        }

        private void AddUserAction_Load(object sender, EventArgs e)
        {
            // Any init code if needed
        }

        // Ensure only one checkbox is selected at a time
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStaff.Checked)
            {
                chkAdmin.Checked = false;
                chkLecturer.Checked = false;
            }
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                chkStaff.Checked = false;
                chkLecturer.Checked = false;
            }
        }

        private void chkLecturer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLecturer.Checked)
            {
                chkStaff.Checked = false;
                chkAdmin.Checked = false;
            }
        }

        // Clear all inputs to empty/default
        private void ClearInputs()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone_Number.Text = "";
            txtPassword.Text = "";
            chkStaff.Checked = false;
            chkAdmin.Checked = false;
            chkLecturer.Checked = false;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone_Number.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = "";

            // Validate all required fields
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your name.");
                txtName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter your phone number.");
                txtPhone_Number.Focus();
                return;
            }
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email.");
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.");
                txtPassword.Focus();
                return;
            }

            // Validate role selection
            if (chkStaff.Checked)
                role = "Staff";
            else if (chkAdmin.Checked)
                role = "Admin";
            else if (chkLecturer.Checked)
                role = "Lecturer";
            else
            {
                MessageBox.Show("Please select one role.");
                return;
            }

            // Insert into database
            using (var conn = DBConfig.GetConnection())
            {
                // Save to role-specific table
                if (role == "Staff")
                {
                    new staffController().CreateStaff(new Staff { Name = name, PhoneNumber = phone, Email = email }, conn);
                }
                else if (role == "Admin")
                {
                    new adminController().CreateAdmin(new Admin { Name = name, PhoneNumber = phone, Email = email }, conn);
                }
                else if (role == "Lecturer")
                {
                    new lecturerController().CreateLecturer(new Lecturer { Name = name, PhoneNumber = phone, Email = email }, conn);
                }

                // Save to Users table
                new userController().CreateUser(new User { Username = email, Password = password, Role = role }, conn);

                conn.Close();
            }

            MessageBox.Show("User created successfully!");
            ClearInputs(); // Reset form
        }
    }
}
