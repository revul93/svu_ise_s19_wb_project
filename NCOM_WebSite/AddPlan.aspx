<%@ Page Title="إضافة الحملات التبرعية" Language="C#" MasterPageFile="~/Masters/ManagerLayout.master" AutoEventWireup="true" CodeFile="AddPlan.aspx.cs" Inherits="AddPlan" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server">
        <asp:Label runat="server" CssClass="required"> اسم الحملة: </asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" CssClass="validation" ControlToValidate="nameTextBox" ErrorMessage="الرجاء إدخال اسم الحملة"></asp:RequiredFieldValidator>
        
        <asp:Label runat="server" CssClass="required"> وصف الحملة: </asp:Label>
        <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" CssClass="validation" ControlToValidate="descriptionTextBox" ErrorMessage="الرجاء إدخال اسم الحملة"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required"> نوع التبرع: </asp:Label>
        <asp:DropDownList ID="methodDropDownList" runat="server" CssClass="form-control">
            <asp:ListItem Value="physical">عيني</asp:ListItem>
            <asp:ListItem Value="cash">نقدي</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label runat="server" CssClass="required"> الكمية المطلوبة: </asp:Label>
        <asp:TextBox ID="amountTextBox" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" CssClass="validation" ControlToValidate="amountTextBox" ErrorMessage="الرجاء إدخال اسم الحملة" SetFocusOnError="true"></asp:RequiredFieldValidator>

        <asp:Button ID="submitButton" runat="server" Text="حفظ" CssClass="form-control button-control" OnClick="submitButton_Click"/>
    </form>
</asp:Content>

