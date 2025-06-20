using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolWebForm
{
    public partial class CourseCRUD : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SchoolDBConnectionString"].ConnectionString;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"INSERT INTO Course (CourseID, CourseName, Credit, TeacherID)
                               VALUES (@CourseID, @CourseName, @Credit, @TeacherID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CourseID", txtCourseID.Text);
                cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@Credit", ddlCredit.SelectedValue);
                cmd.Parameters.AddWithValue("@TeacherID", txtTeacherID.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadGrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"UPDATE Course 
                               SET CourseName=@CourseName, Credit=@Credit, TeacherID=@TeacherID
                               WHERE CourseID=@CourseID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@Credit", ddlCredit.SelectedValue);
                cmd.Parameters.AddWithValue("@TeacherID", txtTeacherID.Text);
                cmd.Parameters.AddWithValue("@CourseID", txtCourseID.Text);
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
                string sql = "SELECT CourseID, CourseName, Credit, TeacherID FROM Course WHERE CourseID LIKE @CourseID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CourseID", "%" + txtCourseID.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCourse.DataSource = dt;
                gvCourse.DataBind();
            }
        }
    }
}
