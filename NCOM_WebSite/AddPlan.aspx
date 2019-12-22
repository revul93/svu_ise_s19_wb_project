<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ManagerLayout.master" AutoEventWireup="true" CodeFile="AddPlan.aspx.cs" Inherits="AddPlan" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server">
        <asp:Label runat="server" CssClass="required"> اسم الحملة: </asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        
        <asp:Label runat="server" CssClass="required"> وصف الحملة: </asp:Label>
        <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        
        <asp:Label runat="server" CssClass="required"> نوع التبرع: </asp:Label>
        <asp:DropDownList ID="methodDropDownList" runat="server" CssClass="form-control">
            <asp:ListItem Value="physical">عيني</asp:ListItem>
            <asp:ListItem Value="cash">نقدي</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label runat="server" CssClass="required"> الكمية المطلوبة: </asp:Label>
        <asp:TextBox ID="amountTextBox" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>

        <asp:Button ID="submitButton" runat="server" Text="إرسال" CssClass="form-control button-control" OnClick="submitButton_Click"/>
    </form>
</asp:Content>

