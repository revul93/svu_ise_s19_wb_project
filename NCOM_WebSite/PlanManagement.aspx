﻿<%@ Page Title="إدارة الحملات التبرعية" Language="C#" MasterPageFile="~/Masters/ManagerLayout.master" AutoEventWireup="true" CodeFile="PlanManagement.aspx.cs" Inherits="Manager" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/list.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form id="form1" runat="server">
    <div class="list-container">
        <asp:PlaceHolder ID="planList" runat="server">
            
        </asp:PlaceHolder>
    </div>
    </form>
</asp:Content>