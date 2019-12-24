<%@ Page Title="إدارة التبرعات" Language="C#" MasterPageFile="~/Masters/ManagerLayout.master" AutoEventWireup="true" CodeFile="DonationManagement.aspx.cs" Inherits="DonationManagement" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/list.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="list-container">
        <form runat="server">
            <asp:PlaceHolder ID="donationList" runat="server">
            </asp:PlaceHolder>
        </form>
    </div>
</asp:Content>