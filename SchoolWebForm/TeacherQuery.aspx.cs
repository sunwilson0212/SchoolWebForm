using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolWebForm
{
    public partial class TeacherQuery : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SchoolDBConnectionString"].ConnectionString;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string empID = txtEmpID.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 查詢教師基本資料
                SqlCommand cmdEmp = new SqlCommand(@"
                    SELECT EmpID, EmpName, Gender, HireDate, IsLeave, EmpTitleID
                    FROM Employee
                    WHERE EmpID = @EmpID", conn);
                cmdEmp.Parameters.AddWithValue("@EmpID", empID);

                SqlDataAdapter da1 = new SqlDataAdapter(cmdEmp);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                gvTeacher.DataSource = dt1;
                gvTeacher.DataBind();

                // 查詢開課清單
                SqlCommand cmdCourses = new SqlCommand(@"
                    SELECT CourseID, CourseName, Credit
                    FROM Course
                    WHERE TeacherID = @EmpID", conn);
                cmdCourses.Parameters.AddWithValue("@EmpID", empID);

                SqlDataAdapter da2 = new SqlDataAdapter(cmdCourses);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                gvCourses.DataSource = dt2;
                gvCourses.DataBind();
            }
        }
    }
}
