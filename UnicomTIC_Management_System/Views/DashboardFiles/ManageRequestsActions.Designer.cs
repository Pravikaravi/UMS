namespace UnicomTIC_Management_System.Views.DashboardFiles
{
    partial class ManageRequestsActions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSignupRequests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSignupRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSignupRequests
            // 
            this.dgvSignupRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvSignupRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSignupRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSignupRequests.ColumnHeadersHeight = 50;
            this.dgvSignupRequests.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvSignupRequests.Location = new System.Drawing.Point(3, 3);
            this.dgvSignupRequests.Name = "dgvSignupRequests";
            this.dgvSignupRequests.RowHeadersVisible = false;
            this.dgvSignupRequests.RowTemplate.Height = 40;
            this.dgvSignupRequests.Size = new System.Drawing.Size(1112, 588);
            this.dgvSignupRequests.TabIndex = 0;
            this.dgvSignupRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ManageRequestsActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSignupRequests);
            this.Name = "ManageRequestsActions";
            this.Size = new System.Drawing.Size(875, 700);
            this.Load += new System.EventHandler(this.ManageRequestsActions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSignupRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSignupRequests;
    }
}
