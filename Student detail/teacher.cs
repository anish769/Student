using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_detail
{
	public partial class teacher : Form
	{
		public teacher()
		{
			InitializeComponent();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (txtName.Text == "")
			{
				MessageBox.Show("Name is required.");
				return;
			}
			String query = "INSERT INTO teacher(TeacherID, TeacherName,TeacherAddress,DOB,Qualification,SubjectOfTeacher) Values('" + txtTeacherID.Text + "','" + txtName.Text + "','" + txtAddress.Text + "','" + txtDOB.Text + "','" + txtQualification.Text + "','" + txtSubject.Text + "')";
			DBConnection.ExecuteNonQuery(query);
			MessageBox.Show("Saved Successfully");
			dataLoad();
			refresh_data();
		}  
		public void dataLoad()
		{

			string load = "select*from teacher";
			gvTeacherDetails.DataSource = DBConnection.GetTableByQuery(load);

		}

		public void refresh_data()
		{
			txtTeacherID.Text = "";
			txtName.Text = "";
			txtDOB.Text = "";
			txtAddress.Text = "";
			txtQualification.Text = "";
			txtSubject.Text = "";
			gvTeacherDetails.Text= "";
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{

			DialogResult result = MessageBox.Show("Do you Want Update Selected Row",
					"Important",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);
			String query = "update  teacher set TeacherName=  '" + txtName.Text + "',TeacherAddress='" + txtAddress.Text + "',DOB='" + txtDOB.Text + "',Qualification='" + txtQualification.Text + "',SubjectOfTeacher='" + txtSubject.Text + "' where TeacherID='" + txtTeacherID.Text + "'";
			DBConnection.ExecuteNonQuery(query);
			MessageBox.Show("Update Successfully");
			dataLoad();
			refresh_data();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Do you Want Delete Selected Row",
				"Important",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				String query = "Delete from  teacher where TeacherID='" + txtTeacherID.Text + "'";
				DBConnection.ExecuteNonQuery(query);
				MessageBox.Show("Deleted Successfully");
				dataLoad();
				refresh_data();
			}
		}

		private void teacher_Load(object sender, EventArgs e)
		{
			dataLoad();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string search = "select TeacherID, TeacherName,TeacherAddress,DOB,Qualification,SubjectOfTeacher from teacher where TeacherID=" + txtSearchT.Text + "";
			var dt = DBConnection.GetTableByQuery(search);
			if (dt.Rows.Count > 0)
			{
				txtTeacherID.Text = dt.Rows[0]["TeacherID"].ToString();
				txtName.Text = dt.Rows[0]["TeacherName"].ToString();
				txtAddress.Text = dt.Rows[0]["TeacherAddress"].ToString();
				txtDOB.Text = dt.Rows[0]["DOB"].ToString();
				txtQualification.Text = dt.Rows[0]["Qualification"].ToString();
				txtSubject.Text = dt.Rows[0]["SubjectOfTeacher"].ToString();
			}
		}

		private void gvTeacherDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			string TeacherID = gvTeacherDetails.CurrentRow.Cells["TeacherID"].Value.ToString();
			string TeacherName = gvTeacherDetails.CurrentRow.Cells["TeacherName"].Value.ToString();
			string TeacherAddress = gvTeacherDetails.CurrentRow.Cells["TeacherAddress"].Value.ToString();
			string DOB = gvTeacherDetails.CurrentRow.Cells["DOB"].Value.ToString();
			string Qualification = gvTeacherDetails.CurrentRow.Cells["Qualification"].Value.ToString();
			string SubjectOfStudent = gvTeacherDetails.CurrentRow.Cells["SubjectOfTeacher"].Value.ToString();

			txtTeacherID.Text = TeacherID;
			txtName.Text = TeacherName;
			txtAddress.Text = TeacherAddress;
			txtDOB.Text = DOB;
			txtQualification.Text = Qualification;
			txtSubject.Text = SubjectOfStudent;
		}
        private void txtSearchT_TextChanged(object sender, EventArgs e)
        {
            string search = "select * from teacher where TeacherName like '" + txtSearchT.Text + "%'";
            gvTeacherDetails.DataSource = DBConnection.GetTableByQuery(search);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
