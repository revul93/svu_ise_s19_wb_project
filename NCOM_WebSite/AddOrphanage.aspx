<%@ Page Title="إضافة دور أيتام" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="AddOrphanage.aspx.cs" Inherits="AddOrphanage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server" class="form-container">
        <asp:Label runat="server" CssClass="required">الإسم: </asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال اسم الدار" ControlToValidate="nameTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server">الشعار: </asp:Label>
        <asp:FileUpload ID="logoFileUpload" runat="server" CssClass="form-control"/>

        <asp:Label runat="server">الوصف: </asp:Label>
        <asp:TextBox ID="descriptionTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>

        <asp:Label runat="server" CssClass="required"> المحافظة: </asp:Label>
        <asp:DropDownList ID="cityDropDownList" runat="server" CssClass="form-control">
            <asp:ListItem>حلب</asp:ListItem>
            <asp:ListItem>دمشق</asp:ListItem>
            <asp:ListItem>حمص</asp:ListItem>
            <asp:ListItem>اللاذقية</asp:ListItem>
            <asp:ListItem>حماة</asp:ListItem>
            <asp:ListItem>ادلب</asp:ListItem>
            <asp:ListItem>طرطوس</asp:ListItem>
            <asp:ListItem>الرقة</asp:ListItem>
            <asp:ListItem>دير الزور</asp:ListItem>
            <asp:ListItem>السويداء</asp:ListItem>
            <asp:ListItem>الحسكة</asp:ListItem>
            <asp:ListItem>درعا</asp:ListItem>
            <asp:ListItem>القنيطرة</asp:ListItem>
        </asp:DropDownList>

         <asp:Label runat="server">عنوان الشارع: </asp:Label>
        <asp:TextBox ID="streetTextBox" runat="server" CssClass="form-control" ></asp:TextBox>

        <asp:Label runat="server" CssClass="required">وصف العنوان: </asp:Label>
        <asp:TextBox ID="addressDescriptionTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال وصف عنوان مختصر" ControlToValidate="addressDescriptionTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required">الهاتف: </asp:Label>
        <asp:TextBox ID="telephoneTextBox" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال رقم الهاتف" ControlToValidate="telephoneTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required">البريد الإلكتروني: </asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control" TextMode="Email" ></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال البريد الالكتروني" ControlToValidate="emailTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required">احداثيات الموقع: </asp:Label>
        <asp:TextBox ID="coordinateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال احداثيات الموقع" ControlToValidate="coordinateTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Label runat="server">السعة: </asp:Label>
        <asp:TextBox ID="capacityTextBox" runat="server" CssClass="form-control" TextMode="Number" ></asp:TextBox>

        <asp:Label runat="server">عدد الأيتام المكفولين: </asp:Label>
        <asp:TextBox ID="sponsoredOrphansTextBox" runat="server" CssClass="form-control" TextMode="Number" ></asp:TextBox>

        <asp:Label runat="server" CssClass="required"> مسؤول الدار: </asp:Label>
        <asp:DropDownList ID="managerDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء اختيار مسؤول الدار" ControlToValidate="addressDescriptionTextBox" runat="server"></asp:RequiredFieldValidator>

        <asp:Button ID="submitButton" runat="server" Text="إضافة دار الأيتام" OnClick="submitButton_Click" CssClass="form-control button-control" />
    </form>
</asp:Content>