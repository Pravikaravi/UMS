using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SQLite;
using UnicomTIC_Management_System.Controllers;
using UnicomTIC_Management_System.Models;
using UnicomTIC_Management_System.Repositories;

namespace UnicomTIC_Management_System.Views
{
    public partial class StudentActions : UserControl
    {
        private studentController controller;
        private int selectedStudentId = -1;

        public StudentActions()
        {
            InitializeComponent();
            controller = new studentController();
            this.Load += StudentActions_Load;
            dgvStudents.SelectionChanged += DgvStudents_SelectionChanged;
            dgvStudents.CellClick += DgvStudents_CellClick; 
        }

        private void StudentActions_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (var conn = DBConfig.GetConnection())
            {
                //conn.Open();
                var dt = controller.GetAllStudents(conn);
                dgvStudents.DataSource = dt;
                dgvStudents.ClearSelection();
                selectedStudentId = -1;

                // Add Edit & Delete button columns if not already added
                if (!dgvStudents.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                    editBtn.HeaderText = "Edit";
                    editBtn.Name = "Edit";
                    editBtn.Text = "✏️";
                    editBtn.UseColumnTextForButtonValue = true;
                    dgvStudents.Columns.Add(editBtn);
                }

                if (!dgvStudents.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = "Delete";
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "🗑️";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    dgvStudents.Columns.Add(deleteBtn);
                }
            }
        }

        private void DgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                selectedStudentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedStudentId = -1;
            }
        }

        private void DgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["Id"].Value);

                if (dgvStudents.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string name = Interaction.InputBox("Edit Name:", "Edit Student", dgvStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(name)) return;

                    string phone = Interaction.InputBox("Edit Phone:", "Edit Student", dgvStudents.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(phone)) return;

                    string email = Interaction.InputBox("Edit Email:", "Edit Student", dgvStudents.Rows[e.RowIndex].Cells["Email"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(email)) return;

                    var updatedStudent = new Student
                    {
                        Id = id,
                        Name = name,
                        Phone_Number = phone,
                        Email = email
                    };

                    using (var conn = DBConfig.GetConnection())
                    {
                        //conn.Open();
                        controller.UpdateStudent(updatedStudent, conn);
                        MessageBox.Show("Student updated successfully");
                        LoadStudents();
                    }
                }
                else if (dgvStudents.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (var conn = DBConfig.GetConnection())
                        {
                            //conn.Open();
                            controller.DeleteStudent(id, conn);
                            MessageBox.Show("Student deleted successfully");
                            LoadStudents();
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Enter Student Name:", "Add Student");
            if (string.IsNullOrWhiteSpace(name)) return;

            string utNumber = Interaction.InputBox("Enter UT Number:", "Add Student");
            if (string.IsNullOrWhiteSpace(utNumber)) return;

            string phone = Interaction.InputBox("Enter Phone Number:", "Add Student");
            if (string.IsNullOrWhiteSpace(phone)) return;

            string email = Interaction.InputBox("Enter Email:", "Add Student");
            if (string.IsNullOrWhiteSpace(email)) return;

            var student = new Student
            {
                Name = name,
                UT_Number = utNumber,
                Phone_Number = phone,
                Email = email
            };

            using (var conn = DBConfig.GetConnection())
            {
                //conn.Open();
                controller.CreateStudent(student, conn);
                MessageBox.Show("Student added successfully");
                LoadStudents();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please use the ✏️ Edit button in the table to update.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please use the 🗑️ Delete button in the table to remove a student.");
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
