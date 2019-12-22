<%@ Page Title="تسجيل الدخول" Language="C#" MasterPageFile="~/Masters/DefaultLayout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Login.css" rel="stylesheet" />
</asp:Content>

    
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form id="form1" runat="server">
        <section class="cover">
            <div class="elements">
                <asp:TextBox ID="usernameTextBox" CssClass="txt1 txtstyle" placeholder="اسم المستخدم" runat="server"></asp:TextBox>
                <asp:TextBox ID="passwordTextBox" CssClass="txt2 txtstyle" placeholder="كلمة السر" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Button ID="loginButton" CssClass="btn1 btnstyle" runat="server" Text="تسجيل دخول" OnClick="loginButton_Click" />
            </div>
        </section>
    </form>
</asp:Content>

