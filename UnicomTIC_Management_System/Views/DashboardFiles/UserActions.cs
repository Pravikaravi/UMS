using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SQLite;
using UnicomTIC_Management_System.Controllers;
using UnicomTIC_Management_System.Models;
using UnicomTIC_Management_System.Repositories;

namespace UnicomTIC_Management_System.Views.DashboardFiles
{
    public partial class UserActions : UserControl
    {
        private userController controller;
        private int selectedUserId = -1;

        public UserActions()
        {
            InitializeComponent();
            controller = new userController();
            this.Load += UserActions_Load;
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            dgvUsers.CellClick += DgvUsers_CellClick;
        }

        private void UserActions_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var dt = controller.GetAllUsers(conn);
                dgvUsers.DataSource = dt;
                dgvUsers.ClearSelection();
                selectedUserId = -1;

                if (!dgvUsers.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                    editBtn.HeaderText = "Edit";
                    editBtn.Name = "Edit";
                    editBtn.Text = "✏️";
                    editBtn.UseColumnTextForButtonValue = true;
                    dgvUsers.Columns.Add(editBtn);
                }

                if (!dgvUsers.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = "Delete";
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "🗑️";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    dgvUsers.Columns.Add(deleteBtn);
                }
            }
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                selectedUserId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedUserId = -1;
            }
        }

        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["Id"].Value);

                if (dgvUsers.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string username = Interaction.InputBox("Edit Username:", "Edit User", dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(username)) return;

                    string password = Interaction.InputBox("Edit Password:", "Edit User", dgvUsers.Rows[e.RowIndex].Cells["Password"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(password)) return;

                    string role = Interaction.InputBox("Edit Role (e.g., Admin/User):", "Edit User", dgvUsers.Rows[e.RowIndex].Cells["Role"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(role)) return;

                    var updatedUser = new User
                    {
                        Id = id,
                        Username = username,
                        Password = password,
                        Role = role
                    };

                    using (var conn = DBConfig.GetConnection())
                    {
                        controller.UpdateUser(updatedUser, conn);
                        MessageBox.Show("User updated successfully");
                        LoadUsers();
                    }
                }
                else if (dgvUsers.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Are you sure to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (var conn = DBConfig.GetConnection())
                        {
                            controller.DeleteUser(id, conn);
                            MessageBox.Show("User deleted successfully");
                            LoadUsers();
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = Interaction.InputBox("Enter Username:", "Add User");
            if (string.IsNullOrWhiteSpace(username)) return;

            string password = Interaction.InputBox("Enter Password:", "Add User");
            if (string.IsNullOrWhiteSpace(password)) return;

            string role = Interaction.InputBox("Enter Role (e.g., Admin/User):", "Add User");
            if (string.IsNullOrWhiteSpace(role)) return;

            var user = new User
            {
                Username = username,
                Password = password,
                Role = role
            };

            using (var conn = DBConfig.GetConnection())
            {
                controller.CreateUser(user, conn);
                MessageBox.Show("User added successfully");
                LoadUsers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please use the ✏️ Edit button in the table to update.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please use the 🗑️ Delete button in the table to remove a user.");
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
