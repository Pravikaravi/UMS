using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UnicomTIC_Management_System.Controllers;
using UnicomTIC_Management_System.Models;
using UnicomTIC_Management_System.Repositories;

namespace UnicomTIC_Management_System.Views.DashboardFiles
{
    public partial class ManageRequestsActions : UserControl
    {
        private studentController studentController = new studentController();
        private userController userController = new userController();

        public ManageRequestsActions()
        {
            InitializeComponent();
            dgvSignupRequests.CellContentClick += dgvSignupRequests_CellContentClick;
            this.Load += ManageRequestsActions_Load;
        }

        private void ManageRequestsActions_Load(object sender, EventArgs e)
        {
            if (dgvSignupRequests.Columns.Count == 0)
            {
                dgvSignupRequests.Columns.Add("Id", "ID");
                dgvSignupRequests.Columns["Id"].Visible = false;
                dgvSignupRequests.Columns.Add("Name", "Name");
                dgvSignupRequests.Columns.Add("UT_Number", "UT Number");
                dgvSignupRequests.Columns.Add("Phone_Number", "Phone_Number");
                dgvSignupRequests.Columns.Add("Email", "Email");
                dgvSignupRequests.Columns.Add("RequestDate", "Requested On");

                var acceptBtn = new DataGridViewButtonColumn { Name = "Accept", Text = "Accept", UseColumnTextForButtonValue = true };
                var declineBtn = new DataGridViewButtonColumn { Name = "Decline", Text = "Decline", UseColumnTextForButtonValue = true };

                dgvSignupRequests.Columns.Add(acceptBtn);
                dgvSignupRequests.Columns.Add(declineBtn);
            }
            LoadSignupRequests();
        }
        
        private void LoadSignupRequests()
        {
            dgvSignupRequests.Rows.Clear();

            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT * FROM SignupRequests ORDER BY Request_Date DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvSignupRequests.Rows.Add(
                            reader["Id"],
                            reader["Name"],
                            reader["UT_Number"],
                            reader["Phone_Number"],
                            reader["Email"],
                            Convert.ToDateTime(reader["Request_Date"]).ToString("dd-MM-yyyy")
                        );
                    }
                }
            }
        }

        private void dgvSignupRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string id = dgvSignupRequests.Rows[e.RowIndex].Cells["Id"].Value.ToString();

            if (dgvSignupRequests.Columns[e.ColumnIndex].Name == "Accept")
                AcceptRequest(id);
            else if (dgvSignupRequests.Columns[e.ColumnIndex].Name == "Decline")
                DeclineRequest(id);

            LoadSignupRequests();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // handle the event here
        }


        private void AcceptRequest(string id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string selectQuery = "SELECT * FROM SignupRequests WHERE Id=@Id";
                using (var cmd = new SQLiteCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var student = new Student
                            {
                                Name = reader["Name"].ToString(),
                                UT_Number = reader["UT_Number"].ToString(),
                                Phone_Number = reader["Phone_Number"].ToString(),
                                Email = reader["Email"].ToString(),
                            };
                            studentController.CreateStudent(student, conn);

                            var user = new User
                            {
                                Username = student.UT_Number,
                                Password = reader["Password"].ToString(),
                                Role = "Student"
                            };
                            userController.CreateUser(user, conn);
                        }
                    }
                }

                string deleteQuery = "DELETE FROM SignupRequests WHERE Id=@Id";
                using (var delCmd = new SQLiteCommand(deleteQuery, conn))
                {
                    delCmd.Parameters.AddWithValue("@Id", id);
                    delCmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Request accepted successfully!", "Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeclineRequest(string id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string deleteQuery = "DELETE FROM SignupRequests WHERE Id=@Id";
                using (var delCmd = new SQLiteCommand(deleteQuery, conn))
                {
                    delCmd.Parameters.AddWithValue("@Id", id);
                    delCmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Request declined.", "Declined", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
