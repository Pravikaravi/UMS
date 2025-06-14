namespace UnicomTIC_Management_System.Views
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.treeAdmin = new System.Windows.Forms.TreeView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblUser_name = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Black;
            this.panelLeft.Controls.Add(this.treeAdmin);
            this.panelLeft.Location = new System.Drawing.Point(2, 1);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(249, 659);
            this.panelLeft.TabIndex = 0;
            // 
            // treeAdmin
            // 
            this.treeAdmin.BackColor = System.Drawing.Color.Black;
            this.treeAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeAdmin.ForeColor = System.Drawing.Color.White;
            this.treeAdmin.ItemHeight = 30;
            this.treeAdmin.Location = new System.Drawing.Point(3, 30);
            this.treeAdmin.Name = "treeAdmin";
            this.treeAdmin.Size = new System.Drawing.Size(243, 626);
            this.treeAdmin.TabIndex = 0;
            this.treeAdmin.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeAdmin_AfterSelect);
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Location = new System.Drawing.Point(257, 58);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1000, 602);
            this.panelRight.TabIndex = 1;
            this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(262, 17);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(387, 28);
            this.lblHeading.TabIndex = 2;
            this.lblHeading.Text = "Welcome to the Admin Dashboard!";
            // 
            // lblUser_name
            // 
            this.lblUser_name.AutoSize = true;
            this.lblUser_name.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser_name.ForeColor = System.Drawing.Color.Brown;
            this.lblUser_name.Location = new System.Drawing.Point(668, 22);
            this.lblUser_name.Name = "lblUser_name";
            this.lblUser_name.Size = new System.Drawing.Size(59, 22);
            this.lblUser_name.TabIndex = 3;
            this.lblUser_name.Text = "label1";
            this.lblUser_name.Click += new System.EventHandler(this.label1_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.lblUser_name);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.panelLeft);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TreeView treeAdmin;
        private System.Windows.Forms.Label lblUser_name;
    }
}