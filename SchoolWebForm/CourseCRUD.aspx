<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseCRUD.aspx.cs" Inherits="SchoolWebForm.CourseCRUD" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>課程管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>📘 課程資料管理</h2>

        課程代碼：<asp:TextBox ID="txtCourseID" runat="server" /><br />
        課程名稱：<asp:TextBox ID="txtCourseName" runat="server" /><br />
        學分數：
        <asp:DropDownList ID="ddlCredit" runat="server">
            <asp:ListItem Text="2" Value="2" />
            <asp:ListItem Text="3" Value="3" />
        </asp:DropDownList><br />
        教師編號（EmpID）：<asp:TextBox ID="txtTeacherID" runat="server" /><br /><br />

        <asp:Button ID="btnAdd" runat="server" Text="新增課程" OnClick="btnAdd_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="修改課程" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnSearch" runat="server" Text="查詢課程" OnClick="btnSearch_Click" />
        <br /><br />

        <asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="true" />
    </form>
</body>
</html>
