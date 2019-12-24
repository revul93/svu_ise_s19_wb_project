<%@ Page Title="إدارة المستخدمين" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserManagement" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/List.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="link-list">
        <div class="link-list-item">
            <a href="AddUser.aspx">إضافة مستخدم</a>
        </div>
        <div class="link-list-item">
            <a href="EditUser.aspx">تعديل مستخدم</a>
        </div>
    </div>"
    <div class="list-container">
        <asp:PlaceHolder ID="usersList" runat="server">

        </asp:PlaceHolder>
    </div>
</asp:Content>

