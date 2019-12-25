<%@ Page Title="التقارير" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form runat="server">
        <asp:panel ID="mainPanel" runat="server" CssClass="form-container">
            <asp:Label runat="server" CssClass="required">دار الأيتام</asp:Label>
            <asp:DropDownList runat="server" ID="orphanageDropDownList" CssClass="form-control" OnSelectedIndexChanged="orphanageDropDownList_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Text="---- اختر دار أيتام لتعديلها ---" selected="selected" disabled="disabled" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </asp:panel>
        <asp:Panel ID="subPanel" runat="server" CssClass="form-container">
            <asp:GridView ID="tableView" runat="server">

            </asp:GridView>
        </asp:Panel>
    </form>
</asp:Content>

