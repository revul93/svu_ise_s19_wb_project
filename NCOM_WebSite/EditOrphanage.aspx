<%@ Page Title="تعديل دور الأيتام" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="EditOrphanage.aspx.cs" Inherits="EditOrphanage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server">
        <asp:panel ID="mainPanel" runat="server" CssClass="form-container">
            <asp:Label runat="server" CssClass="required">دار الأيتام</asp:Label>
            <asp:DropDownList runat="server" ID="orphanageDropDownList" CssClass="form-control" OnSelectedIndexChanged="orphanageDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            
            <asp:Button ID="deleteButton" runat="server" CssClass="btn btn-danger btn-lg form-control button-control" Text="حذف الدار" OnClick="deleteButton_Click" /> 
        </asp:panel>

        <asp:Panel ID="subPanel" runat="server" CssClass="form-container">
            <asp:Label runat="server" CssClass="required">الإسم: </asp:Label>
            <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء إدخال اسم الدار" ControlToValidate="nameTextBox" runat="server"></asp:RequiredFieldValidator>

            <asp:Label runat="server">الشعار: </asp:Label>
            <asp:FileUpload ID="logoFileUpload" runat="server" CssClass="form-control"/>

            <asp:Label runat="server">الوصف: </asp:Label>
            <asp:TextBox ID="descriptionTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>

            <asp:Label runat="server" CssClass="required"> المحافظة: </asp:Label>
            <asp:TextBox ID="cityTextBox" runat="server" CssClass="form-control"></asp:TextBox>

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

            <asp:Button ID="saveButton" runat="server" CssClass="btn btn-success btn-lg button-control" OnClick="saveButton_Click" Text="حفظ التعديلات"/>
        </asp:Panel>
    </form>
</asp:Content>