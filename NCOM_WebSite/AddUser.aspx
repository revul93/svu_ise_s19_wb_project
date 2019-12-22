<%@ Page Title="إضافة مستخدم" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server">
        <asp:Label runat="server" CssClass="required">الإسم: </asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" ></asp:TextBox>

        <asp:Label runat="server" CssClass="required">الوظيفة: </asp:Label>
        <asp:TextBox ID="roleTextBox" runat="server" CssClass="form-control" ></asp:TextBox>

        <asp:Label runat="server" CssClass="required">الهاتف: </asp:Label>
        <asp:TextBox ID="mobileTextBox" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>

        <asp:Label runat="server" CssClass="required">البريد الإلكتروني: </asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control" TextMode="Email" ></asp:TextBox>
    </form>
</asp:Content>

