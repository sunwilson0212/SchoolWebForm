using System;

namespace SchoolWebForm
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentQuery.aspx");
        }

        protected void btnTeacher_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherQuery.aspx");
        }

        protected void btnCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseCRUD.aspx");
        }
    }
}
