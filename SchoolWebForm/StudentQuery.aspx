<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentQuery.aspx.cs" Inherits="SchoolWebForm.StudentQuery" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>學生選課查詢</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>🔍 學生選課查詢</h2>
        學號：
        <asp:TextBox ID="txtStdID" runat="server" />
        <asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" />
        <br /><br />

        <h3>學生基本資料</h3>
        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="true" />

        <h3>已選課程</h3>
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="true" />
    </form>
</body>
</html>
