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
	public partial class student : Form
	{
		public student()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			dataLoad();
            loadcombo();


        }

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void panel2_Paint_1(object sender, PaintEventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{

		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (txtName.Text == "")
			{
				MessageBox.Show("Name is required.");
				return;
			}
			String query = "INSERT INTO student(StudentID, StudentName,StudentAddress,DOB,Remark,RollNo,District) Values('" + txtStudentID.Text + "','"+ txtName.Text + "','" + txtAddress.Text + "','" + txtDOB.Text + "','" + txtRemark.Text + "','" + txtRollNumber.Text+ "','" + cmbDistrict.Text + "')";
			DBConnection.ExecuteNonQuery(query);
			MessageBox.Show("Saved Successfully");
			dataLoad();
			refresh_data();

		}
		public void dataLoad()
		{
		
			string load = "select*from student";
			gvStudentDetails.DataSource=DBConnection.GetTableByQuery(load);

		}

		public void refresh_data()
		{
			txtStudentID.Text = "";
			txtName.Text = "";
			txtDOB.Text = "";
			txtAddress.Text = "";
			txtRemark.Text = "";
            cmbDistrict.Text = "";
			txtRollNumber.Text = "";
		}


		private void txtStudentDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
		{

		}

		private void panel3_Paint_1(object sender, PaintEventArgs e)
		{

		}

		private void panel1_Paint_1(object sender, PaintEventArgs e)
		{

		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Do you Want Update Selected Row",
					"Important",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);
			String query = "update  student set StudentName=  '" + txtName.Text + "',StudentAddress='" + txtAddress.Text + "',DOB='" + txtDOB.Text + "',Remark='" + txtRemark.Text + "',RollNO='" + txtRollNumber.Text + "',District='" + cmbDistrict.Text + "' where StudentID='" + txtStudentID.Text + "'";
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
				String query = "Delete from  student where StudentID='" + txtStudentID.Text + "'";
				DBConnection.ExecuteNonQuery(query);
				MessageBox.Show("Deleted Successfully");
				dataLoad();
				refresh_data();
			}
		}

        private void gvStudentDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string StudentID = gvStudentDetails.CurrentRow.Cells["StudentID"].Value.ToString();
            string StudentName = gvStudentDetails.CurrentRow.Cells["StudentName"].Value.ToString();
            string StudentAddress = gvStudentDetails.CurrentRow.Cells["StudentAddress"].Value.ToString();
            string DOB = gvStudentDetails.CurrentRow.Cells["DOB"].Value.ToString();
            string Remark = gvStudentDetails.CurrentRow.Cells["Remark"].Value.ToString();
            string RollNo = gvStudentDetails.CurrentRow.Cells["RollNo"].Value.ToString();
            string District = gvStudentDetails.CurrentRow.Cells["District"].Value.ToString();

            txtStudentID.Text = StudentID;
            txtName.Text = StudentName;
            txtAddress.Text = StudentAddress;
            txtDOB.Text = DOB;
            txtRemark.Text = Remark;

            txtRollNumber.Text = RollNo;
            cmbDistrict.Text = District;
        }

        private void txtSearchS_TextChanged(object sender, EventArgs e)
        {
            string search = "select * from student where StudentName like '" + txtSearchS.Text + "%'";
            gvStudentDetails.DataSource = DBConnection.GetTableByQuery(search);
        }
        void loadcombo()
        {
            string query = "select*from district";
            var dt = DBConnection.GetTableByQuery(query);
            cmbDistrict.DataSource = dt;
    
            cmbDistrict.ValueMember = "DistrictID";
            cmbDistrict.DisplayMember = "DstrictName";


        }

        private void GvStudentDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
               }

        private void GvStudentDetails_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string StudentID = gvStudentDetails.CurrentRow.Cells["StudentID"].Value.ToString();
            string StudentName = gvStudentDetails.CurrentRow.Cells["StudentName"].Value.ToString();
            string StudentAddress = gvStudentDetails.CurrentRow.Cells["StudentAddress"].Value.ToString();
            string DOB = gvStudentDetails.CurrentRow.Cells["DOB"].Value.ToString();
            string Remark = gvStudentDetails.CurrentRow.Cells["Remark"].Value.ToString();
            string RollNo = gvStudentDetails.CurrentRow.Cells["RollNo"].Value.ToString();
            string District = gvStudentDetails.CurrentRow.Cells["District"].Value.ToString();

            txtStudentID.Text = StudentID;
            txtName.Text = StudentName;
            txtAddress.Text = StudentAddress;
            txtDOB.Text = DOB;
            txtRemark.Text = Remark;

            txtRollNumber.Text = RollNo;
            cmbDistrict.Text = District;
        }
    }

}
