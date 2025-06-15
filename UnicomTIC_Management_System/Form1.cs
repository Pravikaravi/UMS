using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management_System.Design;
using UnicomTIC_Management_System.Repositories;
using UnicomTIC_Management_System.Views;
using System.Text.RegularExpressions;


namespace UnicomTIC_Management_System
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            //controller = new StudentController();
            this.Paint += new PaintEventHandler(formMain_Paint);   

        }

        private void formMain_Load(object sender, EventArgs e)
        {

        }

        // Custom paint method to draw the rounded rectangle
        private void formMain_Paint(object sender, PaintEventArgs e)
        {

            Rectangle rect_header = new Rectangle(1, 1, 1919, 150); // position and size  x,y,width,height
            int radius_header = 10; // corner radius

            DrawRectangle.DrawRoundedRectangle(
                 e.Graphics,
                 rect_header,
                 radius_header,
                 Color.Black,   // border color
                 Color.Black    // fill color
                                // border thickness
            );

            Rectangle rect = new Rectangle(760, 300, 600, 370); // position and size  x,y,width,height
            int radius = 25; // corner radius

            

            // 🖌️ Call your reusable drawing function
            DrawRectangle.DrawRoundedRectangle(
                e.Graphics,
                rect,
                radius,
                Color.White,  // border color
                Color.White,    // fill color
                3f                      // border thickness
            );
        }

        private void formMain_Load_1(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblSignin_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formLogin loginForm = new formLogin();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                if (loginForm.IsAdmin)
                {
                    this.Hide(); // hide main form
                    AdminPanel adminForm = new AdminPanel();
                    adminForm.FormClosed += (s, args) => this.Show(); // show main again when admin closes
                    adminForm.Show();
                }
                else
                {
                    MessageBox.Show("User login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // You can open another form here for regular users
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblSignup_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // 🔍 1. Check empty fields
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtUT_Number.Text) ||
                string.IsNullOrWhiteSpace(txtPhone_Number.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmpassword.Text))
            {
                MessageBox.Show("Please fill in all the fields!");
                return;
            }

            // 📧 2. Email format check
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Invalid email address format!");
                return;
            }

            // 📞 3. Phone number check — only 10 digits
            string phonePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtPhone_Number.Text, phonePattern))
            {
                MessageBox.Show("Phone number must be exactly 10 digits!");
                return;
            }

            // 🎓 4. UT number format check
            string utPattern = @"^UT\d{6}$";
            if (!Regex.IsMatch(txtUT_Number.Text, utPattern))
            {
                MessageBox.Show("UT Number must be 'UT' followed by 6 digits (e.g., UT010008)!");
                return;
            }

            // 🔐 5. Password format check
            string passwordPattern = @"^[a-zA-Z0-9]{6,12}$";
            if (!Regex.IsMatch(txtPassword.Text, passwordPattern))
            {
                MessageBox.Show("Password must be 6–12 characters with letters and numbers only. No symbols allowed!");
                return;
            }

            // 🔁 6. Confirm password
            if (txtPassword.Text != txtConfirmpassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            // ✅ All checks passed, proceed with DB insert
            try
            {
                SQLiteConnection conn = DBConfig.GetConnection();

                string insertQuery = @"
            INSERT INTO SignupRequests (Name, UT_Number, Phone_Number, Email, Password)
            VALUES (@Name, @UT_Number, @Phone, @Email, @Password);";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@UT_Number", txtUT_Number.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone_Number.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // hash later!

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Signup request stored successfully!");

                // 🧹 Clear fields
                txtName.Clear();
                txtUT_Number.Clear();
                txtPhone_Number.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
                txtConfirmpassword.Clear();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
