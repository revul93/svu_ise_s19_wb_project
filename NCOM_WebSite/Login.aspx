<%@ Page Title="تسجيل الدخول" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>

    
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form id="form1" runat="server">
        <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="تسجيل دخول"/>

        <asp:PlaceHolder ID="result" runat="server">
        </asp:PlaceHolder>
    </form>
</asp:Content>

