<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentCRUD.aspx.cs" Inherits="SchoolWebForm.StudentCRUD" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>學生資料管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>學生資料管理</h2>
        學號：<asp:TextBox ID="txtStdID" runat="server" /><br />
        姓名：<asp:TextBox ID="txtName" runat="server" /><br />
        性別：
        <asp:DropDownList ID="ddlGender" runat="server">
            <asp:ListItem Text="男" Value="男" />
            <asp:ListItem Text="女" Value="女" />
        </asp:DropDownList><br />
        學校代碼：<asp:TextBox ID="txtSchoolID" runat="server" /><br />
        科系代碼：<asp:TextBox ID="txtDeptID" runat="server" /><br /><br />

        <asp:Button ID="btnAdd" runat="server" Text="新增學生" OnClick="btnAdd_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="修改學生" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="標記退學" OnClick="btnDelete_Click" />
        <asp:Button ID="btnSearch" runat="server" Text="查詢學生" OnClick="btnSearch_Click" /><br /><br />

        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="true" />
    </form>

</body>
</html>