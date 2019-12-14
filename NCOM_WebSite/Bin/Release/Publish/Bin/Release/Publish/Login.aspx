<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="تسجيل دخول"/>
        <asp:PlaceHolder ID="result" runat="server">

        </asp:PlaceHolder>
    </form>
</body>
</html>
