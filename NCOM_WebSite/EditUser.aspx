<%@ Page Title="تعديل المستخدمين" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="EditUser" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server">
        <asp:panel ID="mainPanel" runat="server" CssClass="form-container">
            <asp:Label runat="server" CssClass="required">المستخدم</asp:Label>
            <asp:DropDownList runat="server" ID="userDropDownList" CssClass="form-control" OnSelectedIndexChanged="userDropDownList_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Text="---- اختر مستخدم لتعديل بياناته ---" selected="selected" disabled="disabled" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </asp:panel>

        <asp:Panel ID="subPanel" runat="server" CssClass="form-container">
            <asp:Label runat="server" CssClass="required">الإسم: </asp:Label>
            <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الاسم لا يمكن أن يكون فارغا" ControlToValidate="nameTextBox" runat="server"></asp:RequiredFieldValidator>

            <asp:Label runat="server" CssClass="required">الوظيفة: </asp:Label>
            <asp:TextBox ID="roleTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="الوظيفة لا يمكن أن تكون فارغة" ControlToValidate="roleTextBox" runat="server"></asp:RequiredFieldValidator>

            <asp:Label runat="server" CssClass="required">الهاتف: </asp:Label>
            <asp:TextBox ID="mobileTextBox" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="رقم الهاتف لا يمكن أن يكون فارغا" ControlToValidate="mobileTextBox" runat="server"></asp:RequiredFieldValidator>

            <asp:Label runat="server" CssClass="required">البريد الإلكتروني: </asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control" TextMode="Email" ></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="البريد الالكتروني لا يمكن أن يكون فارغا" ControlToValidate="emailTextBox" runat="server"></asp:RequiredFieldValidator>

            <asp:Label runat="server" CssClass="required">اسم المستخدم: </asp:Label>
            <asp:TextBox ID="usernameTextBox" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation" ErrorMessage="اسم المستخدم لا يمكن أن يكون فارغا" ControlToValidate="usernameTextBox" runat="server"></asp:RequiredFieldValidator>

            <asp:Button ID="submitButton" runat="server" Text="تعديل البيانات" OnClick="submitButton_Click" CssClass="form-control button-control" />
        </asp:Panel>
    </form>
</asp:Content>

