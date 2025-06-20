using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolWebForm
{
    public partial class StudentQuery : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SchoolDBConnectionString"].ConnectionString;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string stdID = txtStdID.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 查詢學生基本資料
                SqlCommand cmdStudent = new SqlCommand(@"
                    SELECT StdID, StdName, StdGender, StdSchoolID, StdDepID, IsDropOut 
                    FROM Student WHERE StdID = @StdID", conn);
                cmdStudent.Parameters.AddWithValue("@StdID", stdID);

                SqlDataAdapter da1 = new SqlDataAdapter(cmdStudent);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                gvStudent.DataSource = dt1;
                gvStudent.DataBind();

                // 查詢選課資料（JOIN Course）
                SqlCommand cmdCourses = new SqlCommand(@"
                    SELECT C.CourseID, C.CourseName, C.Credit
                    FROM Enrollment E
                    INNER JOIN Course C ON E.CourseID = C.CourseID
                    WHERE E.StdID = @StdID", conn);
                cmdCourses.Parameters.AddWithValue("@StdID", stdID);

                SqlDataAdapter da2 = new SqlDataAdapter(cmdCourses);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                gvCourses.DataSource = dt2;
                gvCourses.DataBind();
            }
        }
    }
}
