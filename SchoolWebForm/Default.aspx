<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolWebForm._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>校務系統主頁</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>🏫 校務系統主選單</h2>

        <asp:Button ID="btnStudent" runat="server" Text="學生選課查詢" OnClick="btnStudent_Click" /><br /><br />
        <asp:Button ID="btnTeacher" runat="server" Text="教師開課查詢" OnClick="btnTeacher_Click" /><br /><br />
        <asp:Button ID="btnCourse" runat="server" Text="課程維護 CRUD" OnClick="btnCourse_Click" />
    </form>
</body>
</html>
