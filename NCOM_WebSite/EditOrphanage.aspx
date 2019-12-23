<%@ Page Title="تعديل دور الأيتام" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="EditOrphanage.aspx.cs" Inherits="EditOrphanage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
    <link href="Style/editDeleteForm.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server">
        <asp:panel ID="mainPanel" runat="server" CssClass="form-container">
            <asp:Label runat="server" CssClass="required">دار الأيتام</asp:Label>
            <asp:DropDownList runat="server" ID="orphanageDropDownList" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الرجاء اختيار دار الأيتام المراد تعديلها" ControlToValidate="orphanageDropDownList" runat="server"></asp:RequiredFieldValidator>
            
            <asp:Button ID="editButton" runat="server" CssClass="btn btn-success btn-lg" Text="تعديل معلومات الدار" OnClick="editButton_Click" />
            <asp:Button ID="deleteButton" runat="server" CssClass="btn btn-danger btn-lg" Text="حذف الدار" OnClick="deleteButton_Click" /> 
        </asp:panel>

        <asp:Panel ID="subPanel" runat="server" CssClass="form-container">

        </asp:Panel>

 
    </form>
</asp:Content>