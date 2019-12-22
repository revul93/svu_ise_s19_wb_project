<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ManagerLayout.master" AutoEventWireup="true" CodeFile="NoPlans.aspx.cs" Inherits="NoPlans" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/SingleContent.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="content">
        <p>لا يوجد حملات تبرع حاليا لعرضها.</p>
        <a href="AddPlan.aspx">قم بإضافة الحملات التبرعية</a>
    </div>
</asp:Content>

