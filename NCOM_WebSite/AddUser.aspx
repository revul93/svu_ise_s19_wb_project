<%@ Page Title="إضافة مستخدم" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server" class="form-container">
        <asp:Label runat="server" CssClass="required">الإسم: </asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال اسم المستخدم" ControlToValidate="nameTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required">الوظيفة: </asp:Label>
        <asp:TextBox ID="roleTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال الوظيفة" ControlToValidate="roleTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required">الهاتف: </asp:Label>
        <asp:TextBox ID="mobileTextBox" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال رقم الهاتف" ControlToValidate="mobileTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required">البريد الإلكتروني: </asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control" TextMode="Email" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال البريد الالكتروني" ControlToValidate="emailTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required">اسم المستخدم: </asp:Label>
        <asp:TextBox ID="usernameTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال أسم السمتخدم" ControlToValidate="usernameTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required">كلمة السر: </asp:Label>
        <asp:TextBox ID="passwordTextBox" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء ادخال كلمة السر" ControlToValidate="passwordTextBox" runat="server"></asp:RequiredFieldValidator>


        <asp:Label runat="server" CssClass="required">تأكيد كلمة السر: </asp:Label>
        <asp:TextBox ID="confirmTextBox" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء تأكيد كلمة السر" ControlToValidate="confirmTextBox" runat="server"></asp:RequiredFieldValidator>
        <asp:CompareValidator CssClass="validation" runat="server" ControlToCompare="passwordTextBox" ControlToValidate="confirmTextBox" ErrorMessage="كلمة السر غير متطابقة"></asp:CompareValidator>

        <asp:Label runat="server" CssClass="required">دار الأيتام المسؤول عنها: </asp:Label>
        <asp:DropDownList runat="server" ID="orphanageDropDownList" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="orphanageDropDownList" CssClass="validation" ErrorMessage="يرجى اختيار دار الأيتام المسؤول عنها المستخدم"></asp:RequiredFieldValidator>

        <asp:Button ID="submitButton" runat="server" Text="تسجيل المستخدم" OnClick="submitButton_Click" CssClass="form-control button-control" />
    </form>
</asp:Content>

