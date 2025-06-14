using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management_System.Controllers;
using UnicomTIC_Management_System.Design;
using UnicomTIC_Management_System.Repositories;
using UnicomTIC_Management_System.Views;

namespace UnicomTIC_Management_System.Views
{
    public partial class formLogin : Form
    {
        public bool IsAdmin { get; private set; }

        public formLogin()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(formMain_Paint);
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
        private void formMain_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(150, 150, 600, 370); // position and size  x,y,width,height
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

        private void txtPhonenumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (UserRepository.ValidateAdminLogin(username, password))
            {
                IsAdmin = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (UserRepository.ValidateUserLogin(username, password))
            {
                IsAdmin = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Create instance of formMain
            formMain mainForm = new formMain();
            mainForm.Show();    // Show the main form
            this.Hide();        // Hide the current login form
        }
    }
}
