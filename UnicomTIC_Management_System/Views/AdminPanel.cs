using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management_System.Views.DashboardFiles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnicomTIC_Management_System.Views
{
    public partial class AdminPanel : Form

    {
        //public string LoggedInUsername { get; set; }
        public AdminPanel()
        {
            InitializeComponent();
            //LoggedInUsername = username;
            //lblUser_name.Text = username; // Set the label text
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // Student Management
            TreeNode studentNode = treeAdmin.Nodes.Add("Student Management");
            studentNode.Nodes.Add("➕ Add Student");
            studentNode.Nodes.Add("📄 View/Edit/Delete Students");
            studentNode.Nodes.Add("📄 Manage requests");

            // User Management
            TreeNode userNode = treeAdmin.Nodes.Add("User Management");
            userNode.Nodes.Add("➕ Add User");
            userNode.Nodes.Add("📄 View/Edit/Delete Users");

            // Course Management
            TreeNode courseNode = treeAdmin.Nodes.Add("Course Management");
            courseNode.Nodes.Add("➕ Add Course");
            courseNode.Nodes.Add("📄 View/Edit/Delete Courses");

            // Subject Management
            TreeNode subjectNode = treeAdmin.Nodes.Add("Subject Management");
            subjectNode.Nodes.Add("➕ Add Subject");
            subjectNode.Nodes.Add("📄 View/Edit/Delete Subjects");

            // Exam Management
            TreeNode examNode = treeAdmin.Nodes.Add("Exam Management");
            examNode.Nodes.Add("➕ Add Exam");
            examNode.Nodes.Add("📄 View Exams");

            // Marks Management
            TreeNode marksNode = treeAdmin.Nodes.Add("Marks Management");
            marksNode.Nodes.Add("➕ Add Marks");
            marksNode.Nodes.Add("📄 View/Edit Marks");

            // Timetable Management
            TreeNode timetableNode = treeAdmin.Nodes.Add("Timetable Management");
            timetableNode.Nodes.Add("➕ Add Timetable Entry");
            timetableNode.Nodes.Add("📄 View/Edit/Delete Timetable");

            // Room Management
            TreeNode roomNode = treeAdmin.Nodes.Add("Room Management");
            roomNode.Nodes.Add("➕ Add Room (Lab or Hall)");
            roomNode.Nodes.Add("📄 View/Edit/Delete Rooms");



            //treeAdmin.ExpandAll();
        }

        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selected = e.Node.Text;
            panelRight.Controls.Clear(); // Only once is enough

            if (selected == "➕ Add Student")
            {
                AddStudentAction addstudentaction = new AddStudentAction();
                addstudentaction.Dock = DockStyle.Fill;
                panelRight.Controls.Add(addstudentaction);
            }
            else if (selected == "📄 View/Edit/Delete Students")
            {
                StudentActions studentactions = new StudentActions();
                studentactions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(studentactions);
            }

            else if (selected == "📄 Manage requests")
            {
                ManageRequestsActions managerequestactions = new ManageRequestsActions();
                managerequestactions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(managerequestactions);
            }
            //==================================================================
            else if (selected == "➕ Add User")
            {
                AddUserAction adduseraction = new AddUserAction();
                adduseraction.Dock = DockStyle.Fill;
                panelRight.Controls.Add(adduseraction);
            }
            else if (selected == "📄 View/Edit/Delete Users")
            {
                UserActions useractions = new UserActions();
                useractions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(useractions);
            }
            //==================================================================
            else if (selected == "➕ Add Course")
            {
                AddCourseAction addcourseaction = new AddCourseAction();
                addcourseaction.Dock = DockStyle.Fill;
                panelRight.Controls.Add(addcourseaction);
            }
            else if (selected == "📄 View/Edit/Delete Courses")
            {
                CourseActions courseactions = new CourseActions();
                courseactions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(courseactions);
            }
            //==================================================================
            else if (selected == "➕ Add Subject")
            {
                AddSubjectAction addsubjectaction = new AddSubjectAction();
                addsubjectaction.Dock = DockStyle.Fill;
                panelRight.Controls.Add(addsubjectaction);
            }
            else if (selected == "📄 View/Edit/Delete Subjects")
            {
                SubjectActions subjectactions = new SubjectActions();
                subjectactions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(subjectactions);
            }

            //==================================================================
            else if (selected == "➕ Add Exam")
            {
                AddExamAction addexamaction = new AddExamAction();
                addexamaction.Dock = DockStyle.Fill;
                panelRight.Controls.Add(addexamaction);
            }
            else if (selected == "📄 View Exams")
            {
                ExamActions examactions = new ExamActions();
                examactions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(examactions);
            }

            //==================================================================
            else if (selected == "➕ Add Marks")
            {
                AddMarksAction addmarksaction = new AddMarksAction();
                addmarksaction.Dock = DockStyle.Fill;
                panelRight.Controls.Add(addmarksaction);
            }
            else if (selected == "📄 View/Edit Marks")
            {
                MarksActions marksactions = new MarksActions();
                marksactions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(marksactions);
            }

            //==================================================================
            else if (selected == "➕ Add Timetable Entry")
            {
                AddTimetableAction addtimetableaction = new AddTimetableAction();
                addtimetableaction.Dock = DockStyle.Fill;
                panelRight.Controls.Add(addtimetableaction);
            }
            else if (selected == "📄 View/Edit/Delete Timetable")
            {
                TimetableActions timetableactions = new TimetableActions();
                timetableactions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(timetableactions);
            }

            //==================================================================
            else if (selected == "➕ Add Room (Lab or Hall)")
            {
                AddRoomAction addroomaction = new AddRoomAction();
                addroomaction.Dock = DockStyle.Fill;
                panelRight.Controls.Add(addroomaction);
            }
            else if (selected == "📄 View/Edit/Delete Rooms")
            {
                RoomActions roomactions = new RoomActions();
                roomactions.Dock = DockStyle.Fill;
                panelRight.Controls.Add(roomactions);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
