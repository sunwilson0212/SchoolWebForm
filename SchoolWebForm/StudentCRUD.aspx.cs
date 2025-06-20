using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolWebForm
{
    public partial class StudentCRUD : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SchoolDBConnectionString"].ConnectionString;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"INSERT INTO Student (StdSchoolID, StdDepID, StdID, StdName, StdGender, IsDropOut)
                               VALUES (@schoolID, @deptID, @stdID, @name, @gender, 0)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@schoolID", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@deptID", txtDeptID.Text);
                cmd.Parameters.AddWithValue("@stdID", txtStdID.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadGrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"UPDATE Student SET StdName=@name, StdGender=@gender, StdSchoolID=@schoolID, StdDepID=@deptID
                               WHERE StdID=@stdID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@schoolID", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@deptID", txtDeptID.Text);
                cmd.Parameters.AddWithValue("@stdID", txtStdID.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"UPDATE Student SET IsDropOut=1 WHERE StdID=@stdID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@stdID", txtStdID.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT StdID, StdName, StdGender, StdSchoolID, StdDepID, IsDropOut FROM Student WHERE StdID LIKE @stdID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@stdID", "%" + txtStdID.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvStudent.DataSource = dt;
                gvStudent.DataBind();
            }
        }
    }
}
