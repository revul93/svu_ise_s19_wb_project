<%@ Page Title="إدارة التبرعات" Language="VB" MasterPageFile="~/Masters/ManagerLayout.master" AutoEventWireup="false" CodeFile="NoDonation.aspx.vb" Inherits="NoDonation" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/SingleContent.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="content">
        <p>لا يوجد تبرعات حاليا.</p>
        <a href="AddPlan.aspx">قم بإضافة الحملات التبرعية لاستقبال التبرعات</a>
    </div>
</asp:Content>

