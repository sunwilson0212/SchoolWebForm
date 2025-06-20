<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherQuery.aspx.cs" Inherits="SchoolWebForm.TeacherQuery" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教師開課查詢</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>🔍 教師開課查詢</h2>
        教師編號（EmpID）：
        <asp:TextBox ID="txtEmpID" runat="server" />
        <asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" />
        <br /><br />

        <h3>教師基本資料</h3>
        <asp:GridView ID="gvTeacher" runat="server" AutoGenerateColumns="true" />

        <h3>開課清單</h3>
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="true" />
    </form>
</body>
</html>
