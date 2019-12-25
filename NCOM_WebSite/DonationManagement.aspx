<%@ Page Title="إدارة التبرعات" Language="C#" MasterPageFile="~/Masters/ManagerLayout.master" AutoEventWireup="true" CodeFile="DonationManagement.aspx.cs" Inherits="DonationManagement" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/list.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="link-list">
        <div class="link-list-item">
            <a href="EditDonation.aspx" class="btn btn-success btn-lg">تعديل التبرعات</a>
        </div>
    </div>
    <div class="list-container">
        <form runat="server">
            <asp:PlaceHolder ID="donationList" runat="server">
            </asp:PlaceHolder>
        </form>
    </div>
</asp:Content>