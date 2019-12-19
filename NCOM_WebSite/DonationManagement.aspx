<%@ Page Title="إدارة الحملات التبرعية" Language="C#" MasterPageFile="~/Masters/DefaultLayout.master" AutoEventWireup="true" CodeFile="DonationManagement.aspx.cs" Inherits="DonationManagement" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/list.css" rel="stylesheet" />s
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="list-container">
        <asp:PlaceHolder ID="donationList" runat="server">

        </asp:PlaceHolder>
    </div>
</asp:Content>