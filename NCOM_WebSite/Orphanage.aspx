<%@ Page Title="دور الأيتام" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Orphanage.aspx.cs" Inherits="Orphanage" %>

<asp:Content ID="headConetent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Orphanage.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="listContainer">
        <asp:PlaceHolder ID="orphanagesList" runat="server">

        </asp:PlaceHolder>
    </div>
</asp:Content>

