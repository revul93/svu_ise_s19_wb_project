﻿<%@ Page Title="دور الأيتام" Language="C#" MasterPageFile="~/Masters/DefaultLayout.master" AutoEventWireup="true" CodeFile="Orphanage.aspx.cs" Inherits="Orphanage" %>

<asp:Content ID="headConetent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/list.css" rel="stylesheet" />
    <link href="Style/Orphanage.css" rel="stylesheet" />
    <asp:PlaceHolder ID="headPlaceHolder" runat="server">

    </asp:PlaceHolder>
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="list-container">
        <asp:PlaceHolder ID="orphanagesList" runat="server">

        </asp:PlaceHolder>
    </div>
</asp:Content>

